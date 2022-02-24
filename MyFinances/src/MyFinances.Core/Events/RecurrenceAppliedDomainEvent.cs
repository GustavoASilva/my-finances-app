using MediatR;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Core.Events
{

    public class RecurrenceAppliedDomainEvent : INotification
    {
        public RecurrenceAppliedDomainEvent(DateOnly estimatedTransactionDate, string name, decimal value, Category category, int householdId, int originId)
        {
            EstimatedTransactionDate = estimatedTransactionDate;
            Value = value;
            Category = category;
            HouseholdId = householdId;
            OriginId = originId;
            Name = name;
        }

        public DateOnly EstimatedTransactionDate { get; }
        public decimal Value { get; }
        public Category Category { get; }
        public int HouseholdId { get; }
        public int OriginId { get; }
        public string Name { get; }
    }
}
