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

        public Transaction(decimal value,  Category category, int householdId, string description)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            

            Category = category;
            HouseholdId = householdId;
            Description = description;
        }

        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public int HouseholdId { get; private set; }
        public int OriginId { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }


        //public void SetConfirmedDate(DateTime confirmedDate)
        //{
        //    ConfirmedDate = confirmedDate;
        //}

        //public void SetEstimatedDate(DateTime estimatedDate)
        //{
        //    EstimatedDate = estimatedDate;
        //}

        public void SetHouseholdId(int householdId)
        {
            HouseholdId = householdId;
        }

        
    }
}