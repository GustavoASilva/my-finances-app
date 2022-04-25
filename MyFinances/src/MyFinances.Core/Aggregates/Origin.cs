using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Origin : BaseEntity<int>, IAggregateRoot
    {
        public Origin()
        {
        }

        public Origin(string alias, int householdId)
        {
            Alias = alias;
            HouseholdId = householdId;
        }

        public string Alias { get; private set; } = default!;
        public int HouseholdId { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public void SetDeletedAt(DateTime dateTime)
        {
            DeletedAt = dateTime;
        }
    }
}