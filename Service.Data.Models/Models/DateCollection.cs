using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Data.Models.Models
{
    public class DateCollection
    {
        public DateCollection(DateTime currentDate)
        {
            Date = currentDate;
        }

        public DateCollection()
        {
        }

        public int DateCollectionId { get; set; }
        public DateTime Date { get; set; }

        public virtual IList<Payment> Payments { get; set; }

        [NotMapped]
        public string PaymentSummary { get; set; }

        [NotMapped]
        public double TotalBalanceForCollection { get; set; }

        [NotMapped]
        public bool IsCollectionPositive { get; set; }
        //            ? Payments.Sum(m => m.PaymentAmount).ToString("C")
        //        return Payments != null && Payments.Any()
        //    {
        //    get
        //{
        //public string PaymentsSummary
        //[NotMapped]
        //            : string.Empty;
        //    }
        //}

        //[NotMapped]
        //public double TotalBalanceForCollection => Payments?.Sum(m => m.PaymentAmount) ?? 0;

        //[NotMapped]
        //public bool IsCollectionPositive => TotalBalanceForCollection >= 0;
    }
}