using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public void Apply()
        {
            if (CanApply())
            {
                UpdateLatestOccurrence();

                var nextDate = GetNextOccurrenceDate();
                var recurrenceAppliedEvent = new RecurrenceAppliedDomainEvent(nextDate, Value, Category, Description, HouseholdId, OriginId);
                AddDomainEvent(recurrenceAppliedEvent);
            }
        }

        public DateTime StartDate { get; private set; }
        public bool IsActive { get; private set; } = true;

        public DateTime? LatestOccurrence { get; private set; }

        public readonly RecurrenceType Type = RecurrenceType.Monthly;
        public decimal Value { get; }
        public Category Category { get; }
        public string Description { get; }
        public int HouseholdId { get; }
        public int OriginId { get; }

        public bool CanApply()
        {
            throw new NotImplementedException();
        }

        public void SetIsActive(bool v)
        {
            throw new NotImplementedException();
        }

        private void UpdateLatestOccurrence()
        {
            throw new NotImplementedException();
        }

        private DateTime GetNextOccurrenceDate()
        {
            return DateTime.UtcNow;
        }
    }
}