namespace MyFinances.Blazor.Client.Models
{
    public class TransactionCreateDto
    {
        public TransactionCreateDto()
        {
        }

        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public bool IsConfirmed { get; set; }
        public int OriginId { get; set; }
        public string Description { get; set; } = default!;
        public int CategoryId { get; set; }
    }
}