using Ardalis.GuardClauses;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Transaction : BaseEntity<Guid>, IAggregateRoot
    {
        public Transaction()
        {
        }

        public Transaction(decimal value, DateTime estimatedDate, DateTime? confirmedDate, Category category, int householdId, string description)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            EstimatedDate = Guard.Against.Default(estimatedDate, nameof(EstimatedDate));
            ConfirmedDate = confirmedDate;
            Category = category;
            HouseholdId = householdId;
            Description = description;
        }

        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }
        public Category Category { get; private set; }
        public int HouseholdId { get; private set; }
        public int OriginId { get; private set; }

        public void SetConfirmedDate(DateTime confirmedDate)
        {
            ConfirmedDate = confirmedDate;
        }

        public void SetHouseholdId(int householdId)
        {
            HouseholdId = householdId;
        }

        public void SetEstimatedDate(DateTime estimatedDate)
        {
            EstimatedDate = estimatedDate;
        }
    }
}