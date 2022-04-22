namespace MyFinances.Blazor.Shared.Recurrence
{
    public class RecurrenceDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime? LatestOccurrence { get; set; }
        public DateTime NextOccurrence { get; set; }
        public int DaysInterval { get; set; }
        public decimal Value { get; set; }
        public string Name { get; set; } = default!;
        public int OriginId { get; set; }
    }
}