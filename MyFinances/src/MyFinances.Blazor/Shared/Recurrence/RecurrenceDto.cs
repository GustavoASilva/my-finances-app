using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Shared.Recurrence
{
    public class RecurrenceDto
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public bool IsActive { get; set; }
        public DateOnly? LatestOccurrenceDate { get; set; }
        public DateOnly NextOccurrenceDate { get; set; }
        public int DaysInterval { get; set; }
        public decimal Value { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int HouseholdId { get; set; }
        public int OriginId { get; set; }
    }
}
