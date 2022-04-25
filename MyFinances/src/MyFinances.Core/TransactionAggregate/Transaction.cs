using Ardalis.GuardClauses;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Core.TransactionAggregate
{
    public class Transaction : BaseEntity<Guid>, IAggregateRoot
    {
        public Transaction()
        {
        }

        public Transaction(decimal value,
                           int categoryId,
                           int householdId,
                           int originId,
                           string description,
                           DateTime estimatedDate,
                           DateTime? confirmedDate)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            HouseholdId = householdId;
            Description = description;
            EstimatedDate = estimatedDate;
            ConfirmedDate = confirmedDate;
            OriginId = originId;
            _categoryId = categoryId;
        }

        public Transaction(decimal value,
                           int categoryId,
                           int householdId,
                           int originId,
                           string description,
                           DateTime estimatedDate)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            HouseholdId = householdId;
            Description = description;
            EstimatedDate = estimatedDate;
            OriginId = originId;
            _categoryId = categoryId;
        }       

        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public TransactionCategory Category { get; set; } = default!;
        public int HouseholdId { get; private set; }
        public int OriginId { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }
        public bool IsConfirmed { get; private set; }
        private int _categoryId;

        public void UpdateValue(decimal value)
        {
            Value = value;
        }
        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void SetConfirmed(bool confirmed)
        {
            if (confirmed)
                Confirm();
            else
                Unconfirm();
        }

        public void UpdateEstimatedDate(DateTime estimatedDate)
        {
            EstimatedDate = estimatedDate;
        }

        private void Confirm()
        {
            if (IsConfirmed) return;

            ConfirmedDate = DateTime.Now;
            IsConfirmed = true;
        }

        private void Unconfirm()
        {
            if (!IsConfirmed) return;
            IsConfirmed = false;
            ConfirmedDate = null;
        }
    }
}