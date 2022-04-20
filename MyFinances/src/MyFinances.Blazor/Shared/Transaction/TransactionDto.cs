namespace MyFinances.Blazor.Shared.Transaction
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public int OriginId { get; set; }
        public string Category { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string OriginName { get; set; } = default!;
    }
}
