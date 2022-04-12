using MediatR;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Core.Events
{

    public class RecurrenceAppliedDomainEvent : INotification
    {
        public RecurrenceAppliedDomainEvent(DateOnly estimatedTransactionDate,
                                            string name,
                                            decimal value,
                                            int categoryId,
                                            int householdId,
                                            int originId)
        {
            EstimatedTransactionDate = estimatedTransactionDate;
            Value = value;
            CategoryId = categoryId;
            HouseholdId = householdId;
            OriginId = originId;
            Name = name;
        }

        public DateOnly EstimatedTransactionDate { get; }
        public decimal Value { get; }
        public int CategoryId { get; }
        public int HouseholdId { get; }
        public int OriginId { get; }
        public string Name { get; }
    }
}
