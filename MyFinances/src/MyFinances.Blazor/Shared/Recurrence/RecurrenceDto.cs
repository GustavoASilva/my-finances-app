using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Shared.Recurrence
{
    public class RecurrenceDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? LatestOccurrence { get; set; }
        public DateTime NextOccurrence { get; set; }
        public int DaysInterval { get; set; }
        public decimal Value { get; set; }
        public Category TransactionCategory { get; set; }
        public string Name { get; set; }
        public int OriginId { get; set; }
    }
}