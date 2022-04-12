using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Client.Models
{
    public class RecurrenceCreateDto
    {
        public DateTime? Start;
        public DateTime? End;
        public int DaysInterval;
        public decimal Value;
        public int TransactionCategoryId;
        public string Name;
        public int OriginId;
    }
}
