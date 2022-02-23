using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public DateOnly StartDate { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateOnly? LatestOccurrenceDate { get; private set; }
        public DateOnly NextOccurrenceDate { get; private set; }
        public int DaysInterval { get; private set; }
        public decimal Value { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public int HouseholdId { get; private set; }
        public int OriginId { get; private set; }

        public void Apply()
        {
            if (CanApply())
            {
                UpdateLatestOccurrenceDate();
                UpdateNextOccurrence();

                var recurrenceAppliedEvent = new RecurrenceAppliedDomainEvent(NextOccurrenceDate, Value, Category, Description, HouseholdId, OriginId);

                AddDomainEvent(recurrenceAppliedEvent);
            }
        }

        private bool CanApply()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return IsActive
                && StartDate >= today
                && today <= NextOccurrenceDate.AddMonths(-1);
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        private void UpdateLatestOccurrenceDate()
        {
            LatestOccurrenceDate = DateOnly.FromDateTime(DateTime.Now);

        }

        private void UpdateNextOccurrence()
        {
            if (LatestOccurrenceDate.HasValue)
                NextOccurrenceDate = LatestOccurrenceDate.Value.AddDays(DaysInterval);
        }
    }
}