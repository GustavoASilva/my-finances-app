using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public DateTime StartDate { get; private set; }
        public bool IsActive { get; private set; } = true;

        public DateTime? LatestOccurrence { get; private set; }

        public  RecurrenceType Type { get; private set; } = RecurrenceType.Monthly;
        public decimal Value { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public int HouseholdId { get; private set; }
        public int OriginId { get; private set; }

        public void Apply()
        {
            if (CanApply())
            {
                UpdateLatestOccurrence();

                var nextDate = GetNextOccurrenceDate();
                var recurrenceAppliedEvent = new RecurrenceAppliedDomainEvent(nextDate, Value, Category, Description, HouseholdId, OriginId);
                
                Description = "teste2";

                AddDomainEvent(recurrenceAppliedEvent);
            }
        }

        public bool CanApply()
        {
            //throw new NotImplementedException();
            return true;
        }

        public void SetIsActive(bool v)
        {
            throw new NotImplementedException();
        }

        private void UpdateLatestOccurrence()
        {
            //throw new NotImplementedException();
        }

        private DateTime GetNextOccurrenceDate()
        {
            return DateTime.UtcNow;
        }
    }
}