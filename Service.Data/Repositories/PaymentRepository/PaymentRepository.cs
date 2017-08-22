using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Service.Data.Contexts;
using Service.Data.Models.Models;
using Service.Global.Extensions;

namespace Service.Data.Repositories.PaymentRepository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly IList<Action<IEnumerable<DateCollection>>> _subscribers =
            new List<Action<IEnumerable<DateCollection>>>();

        public PaymentRepository() : base(new DbFinContext())
        {
        }

        public async Task<bool> AddPaymentAsync(DateTime date, Payment payment)
        {
            using (var context = new DbFinContext())
            {
                var dateRecord = await context.Dates.FirstOrDefaultAsync(m => m.Date == date) ??
                                 new DateCollection(date);

                if (dateRecord.Payments.IsNull())
                    dateRecord.Payments = new List<Payment>();

                dateRecord.Payments.Add(payment);

                context.Dates.AddOrUpdate(dateRecord);
                return context.SaveChanges() == 0;
            }
        }

        public async Task<bool> RemovePaymentAsync(DateTime date, Payment payment)
        {
            using (var context = new DbFinContext())
            {
                var recordExists = await context.Dates.FirstOrDefaultAsync(m => m.Date == date);
                var recordedPayment = recordExists?.Payments.FirstOrDefault(m => m.PaymentId == payment.PaymentId);

                if (recordedPayment != null)
                    recordExists?.Payments.Remove(recordedPayment);

                return context.SaveChanges() == 0;
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

        public void Subscribe(Action<IEnumerable<DateCollection>> onCollectionChangedAction)
        {
            InternalSubscribe(onCollectionChangedAction);
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
        
        private void InternalSubscribe(Action<IEnumerable<DateCollection>> onCollectionChangedAction)
        {
            if (!_subscribers.Contains(onCollectionChangedAction))
                _subscribers.Add(onCollectionChangedAction);
        }
    }
}