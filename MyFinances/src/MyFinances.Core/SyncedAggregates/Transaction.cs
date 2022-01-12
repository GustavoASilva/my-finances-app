using Ardalis.GuardClauses;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Transaction : BaseEntity<Guid>, IAggregateRoot
    {
        public Transaction()
        {
        }

        public Transaction(decimal value, DateTime estimatedDate, DateTime? confirmedDate, Category category, int householdId)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            EstimatedDate = Guard.Against.Default(estimatedDate, nameof(EstimatedDate));
            ConfirmedDate = confirmedDate;
            Category = category;
            HouseholdId = householdId;
        }

        public decimal Value { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }
        public Category Category { get; private set; }
        public int HouseholdId { get; private set; }

        public void Confirm()
        {
            if (ConfirmedDate != null) return;

            ConfirmedDate = DateTime.Now;
        }
    }
}