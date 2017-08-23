using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Data.Models.Models;

namespace Service.Data.Repositories.PaymentRepository
{
    public interface IPaymentRepository
    {
        Task<bool> AddPaymentAsync(DateTime date, Payment payment);
        Task<bool> RemovePaymentAsync(DateTime date, Payment payment);
        Task<DateCollection> GetPaymentsForDateTimeAsync(DateTime dateTime);
        Task<List<Payment>> GetPaymentsForDateTimeCollectionAsync(DateCollection collection);
        Task<IEnumerable<DateCollection>> GetPaymentDateCollectionsForMonthAsync(DateTime dateTime);
    }
}