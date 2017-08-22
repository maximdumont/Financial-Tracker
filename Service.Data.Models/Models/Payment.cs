namespace Service.Data.Models.Models
{
    public class Payment
    {
        public Payment(string paymentName, double paymentAmount)
        {
            PaymentName = paymentName;
            PaymentAmount = paymentAmount;
        }

        public Payment()
        {
        }

        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public double PaymentAmount { get; set; }
    }
}