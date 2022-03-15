using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Client.Models
{
    public class RecurrenceCreate
    {
        public DateTime? Start;
        public DateTime? End;
        public int DaysInterval;
        public decimal Value;
        public Category TransactionCategory;
        public string Name;
        public int OriginId;
    }
}
