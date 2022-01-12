namespace MyFinances.Blazor.Shared
{
    public class AddNewTransactionRequest
    {
        public AddNewTransactionRequest()
        {
        }

        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
    }
}
