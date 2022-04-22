namespace MyFinances.Blazor.Shared.Transaction
{
    public class UpdateTransactionRequest
    {
        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public int CategoryId { get; set; }
        public int OriginId { get; set; }
        public string Description { get; set; } = default!;
        public bool Confirmed { get; set; }
    }
}
