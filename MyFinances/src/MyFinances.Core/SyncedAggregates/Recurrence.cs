using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public Recurrence(DateOnly startDate, int daysInterval, decimal value, Category category, string description, int householdId, int originId)
        {
            StartDate = startDate;
            DaysInterval = daysInterval;
            Value = value;
            Category = category;
            Description = description;
            HouseholdId = householdId;
            OriginId = originId;
            IsActive = true;
            NextOccurrenceDate = startDate;
        }

        public DateOnly StartDate { get; private set; }
        public bool IsActive { get; private set; }
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

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        private bool CanApply()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return IsActive
                && StartDate >= today
                && today <= NextOccurrenceDate.AddMonths(-1);
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