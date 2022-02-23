using MediatR;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Core.Events
{

    public class RecurrenceAppliedDomainEvent : INotification
    {
        public RecurrenceAppliedDomainEvent(DateOnly estimatedTransactionDate, decimal value, Category category, string description, int householdId, int originId)
        {
            EstimatedTransactionDate = estimatedTransactionDate;
            Value = value;
            Category = category;
            Description = description;
            HouseholdId = householdId;
            OriginId = originId;
        }

        public DateOnly EstimatedTransactionDate { get; }
        public decimal Value { get; }
        public Category Category { get; }
        public string Description { get; }
        public int HouseholdId { get; }
        public int OriginId { get; }
    }
}
