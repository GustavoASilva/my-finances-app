namespace MyFinances.Blazor.Shared.Transaction
{
    public class GetTransactionsInRangeResponse
    {
        public GetTransactionsInRangeResponse()
        {
        }

        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int OriginId { get; set; }
    }
}
