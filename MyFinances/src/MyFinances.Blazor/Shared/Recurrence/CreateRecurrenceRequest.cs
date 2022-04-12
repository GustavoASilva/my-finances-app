using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Shared.Recurrence
{
    public class CreateRecurrenceRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int DaysInterval { get; set; }
        public decimal Value { get; set; }
        public int TransactionCategoryId { get; set; }
        public string Name { get; set; }
        public int OriginId { get; set; }
    }
}