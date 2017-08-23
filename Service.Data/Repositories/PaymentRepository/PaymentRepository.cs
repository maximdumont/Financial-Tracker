using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Logging;
using Service.Data.Contexts;
using Service.Data.Models.Models;
using Service.Global.Events.Data;
using Service.Global.Extensions;
using Service.Global.Logging;

namespace Service.Data.Repositories.PaymentRepository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataCollectionChangedEvent _collectionChangedEvent;
        private readonly IFinancialTrackerLogger _financialTrackerLogger;
        private DateTime _lastLoggedDateCollectionDate;

        public PaymentRepository(IEventAggregator eventAggregator, IFinancialTrackerLogger logger)
        {
            _financialTrackerLogger = logger;
            _collectionChangedEvent = eventAggregator.GetEvent<DataCollectionChangedEvent>();
        }

        public async Task<bool> AddPaymentAsync(DateTime date, Payment payment)
        {
            var isSuccess = true;
            using (var context = new DbFinContext())
            {
                try
                {
                    var dateRecord = context.Dates.FirstOrDefault(m => m.Date == date) ??
                                     new DateCollection(date);

                    if (dateRecord.Payments.IsNull())
                        dateRecord.Payments = new List<Payment>();

                    dateRecord.Payments.Add(payment);
                    _lastLoggedDateCollectionDate = dateRecord.Date;
                    context.Dates.AddOrUpdate(dateRecord);
                    await context.SaveChangesAsync().ContinueWith(PublishUpdatedCollection);
                }
                catch (EntityException exception)
                {
                    isSuccess = false;
                    _financialTrackerLogger.Log(exception.Message, Category.Exception, Priority.High);
                }
                return isSuccess;
            }
        }

        public async Task<bool> RemovePaymentAsync(DateTime date, Payment payment)
        {
            var isSuccess = true;
            using (var context = new DbFinContext())
            {
                try
                {
                    var recordExists = await context.Dates.FirstOrDefaultAsync(m => m.Date == date);
                    var recordedPayment = recordExists?.Payments.FirstOrDefault(m => m.PaymentId == payment.PaymentId);

                    if (recordedPayment != null)
                        recordExists?.Payments.Remove(recordedPayment);

                    _lastLoggedDateCollectionDate = recordExists?.Date ?? DateTime.Now;
                    await context.SaveChangesAsync().ContinueWith(PublishUpdatedCollection);
                }
                catch (EntityException exception)
                {
                    isSuccess = false;
                    _financialTrackerLogger.Log(exception.Message, Category.Exception, Priority.High);
                }
                return isSuccess;
            }
        }

        public async Task<IEnumerable<DateCollection>> GetPaymentDateCollectionsForMonthAsync(DateTime dateTime)
        {
            using (var context = new DbFinContext())
            {
                var collection = new List<DateCollection>();
                var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

                var currentDate = new DateTime(dateTime.Year, dateTime.Month, 1);
                for (var day = 0; day < daysInMonth; day++)
                {
                    if (day > 0)
                        currentDate = currentDate.AddDays(1);

                    var currentDateCollection = await context.Dates.FirstOrDefaultAsync(m => m.Date == currentDate);
                    if (currentDateCollection.IsNull())
                        currentDateCollection = new DateCollection(currentDate);

                    currentDateCollection.TotalBalanceForCollection =
                        currentDateCollection.Payments?.Sum(m => m.PaymentAmount) ?? 0;
                    currentDateCollection.PaymentSummary =
                        currentDateCollection.Payments?.Sum(m => m.PaymentAmount).ToString("C") ?? string.Empty;
                    currentDateCollection.IsCollectionPositive = currentDateCollection.TotalBalanceForCollection >= 0;

                    collection.Add(currentDateCollection);
                }

                var orderedCollection = collection.OrderBy(m => m.Date.Day).ToList();
                return orderedCollection;
            }
        }


        public Task<DateCollection> GetPaymentsForDateTimeAsync(DateTime dateTime)
        {
            return Task.Factory.StartNew(delegate
            {
                using (var context = new DbFinContext())
                {
                    return context.Dates.FirstOrDefault(m => m.Date == dateTime);
                }
            });
        }

        public Task<List<Payment>> GetPaymentsForDateTimeCollectionAsync(DateCollection collection)
        {
            return Task.Factory.StartNew(delegate
            {
                using (var context = new DbFinContext())
                {
                    var dbCollection =
                        context.Dates.FirstOrDefault(m => m.DateCollectionId == collection.DateCollectionId);

                    return dbCollection?.Payments.ToList();
                }
            });
        }

        private async void PublishUpdatedCollection(Task task)
        {
            if (task.Status == TaskStatus.Faulted || task.Status != TaskStatus.RanToCompletion)
                _financialTrackerLogger.Log(task.Status.ToString(), Category.Exception, Priority.High);

            var collection = await GetPaymentDateCollectionsForMonthAsync(_lastLoggedDateCollectionDate);
            _collectionChangedEvent.Publish(collection);
        }
    }
}