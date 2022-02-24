using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public Recurrence()
        {
        }

        public Recurrence(DateTime start, int daysInterval, decimal value, Category transactionCategory, string description, int householdId, int originId)
        {
            DateOnly startDate = DateOnly.FromDateTime(start);

            Start = startDate;
            DaysInterval = daysInterval;
            Value = value;
            TransactionCategory = transactionCategory;
            Name = description;
            HouseholdId = householdId;
            OriginId = originId;
            NextOccurrence = startDate;
        }

        public DateOnly Start { get; private set; }
        public DateOnly? LatestOccurrence { get; private set; }
        public DateOnly NextOccurrence { get; private set; }
        public int DaysInterval { get; private set; }
        public decimal Value { get; private set; }
        public Category TransactionCategory { get; private set; }
        public string Name { get; private set; }
        public int HouseholdId { get; private set; }
        public int OriginId { get; private set; }

        public void Apply()
        {
            if (CanApply())
            {
                UpdateLatestOccurrence();
                UpdateNextOccurrence();

                var recurrenceAppliedEvent = new RecurrenceAppliedDomainEvent(NextOccurrence, Name, Value, TransactionCategory, HouseholdId, OriginId);

                AddDomainEvent(recurrenceAppliedEvent);
            }
        }

        private bool CanApply()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return Start >= today 
                && today <= NextOccurrence.AddMonths(-1);
        }

        private void UpdateLatestOccurrence()
        {
            LatestOccurrence = DateOnly.FromDateTime(DateTime.Now);
        }

        private void UpdateNextOccurrence()
        {
            if (LatestOccurrence.HasValue)
                NextOccurrence = LatestOccurrence.Value.AddDays(DaysInterval);
        }
    }
}