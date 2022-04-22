namespace MyFinances.Blazor.Client.Models
{
    public class RecurrenceCreateDto
    {
        public RecurrenceCreateDto()
        {
        }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int DaysInterval { get; set; }
        public decimal Value { get; set; }
        public int TransactionCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public int OriginId { get; set; }
    }
}
