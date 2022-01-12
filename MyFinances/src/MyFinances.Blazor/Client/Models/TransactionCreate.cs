namespace MyFinances.Blazor.Client.Models
{
    public class TransactionCreate
    {
        public TransactionCreate()
        {
        }

        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
