using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public Recurrence(DateTime start,
                          DateTime end,
                          int daysInterval,
                          decimal value,
                          int transactionCategoryId,
                          string description,
                          int householdId,
                          int originId)
        {
            DateOnly startDate = DateOnly.FromDateTime(start);
            DateOnly endDate = DateOnly.FromDateTime(end);

            Start = startDate;
            End = endDate;
            DaysInterval = daysInterval;
            Value = value;
            Name = description;
            HouseholdId = householdId;
            OriginId = originId;
            NextOccurrence = startDate;
            _transactionCategoryId = transactionCategoryId;
        }

        public DateOnly Start { get; private set; }
        public DateOnly End { get; private set; }
        public DateOnly? LatestOccurrence { get; private set; }
        public DateOnly NextOccurrence { get; private set; }
        public int DaysInterval { get; private set; }
        public decimal Value { get; private set; }
        public TransactionCategory TransactionCategory { get; private set; } = default!;
        public string Name { get; private set; }
        public int HouseholdId { get; private set; }
        public int OriginId { get; private set; }
        private int _transactionCategoryId;

        public void Apply()
        {
            UpdateLatestOccurrence();
            UpdateNextOccurrence();

            RecurrenceAppliedDomainEvent recurrenceAppliedEvent = new(NextOccurrence, Name, Value, _transactionCategoryId, HouseholdId, OriginId);

            AddDomainEvent(recurrenceAppliedEvent);
        }

        public bool CanBeApplied()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return Start == today
                && today <= End
                && today >= NextOccurrence.AddMonths(-1);
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