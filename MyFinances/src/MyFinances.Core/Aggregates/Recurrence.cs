using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public Recurrence()
        {
        }

        public Recurrence(DateOnly start,
                          DateOnly end,
                          int daysInterval,
                          decimal value,
                          int transactionCategoryId,
                          string name,
                          int householdId,
                          int originId)
        {
            Start = start;
            End = end;
            DaysInterval = daysInterval;
            Value = value;
            Name = name;
            HouseholdId = householdId;
            OriginId = originId;
            NextOccurrence = start;
            _transactionCategoryId = transactionCategoryId;
        }

        public DateOnly Start { get; private set; }
        public DateOnly End { get; private set; }
        public DateOnly? LatestOccurrence { get; private set; }
        public DateOnly NextOccurrence { get; private set; }
        public int DaysInterval { get; private set; }
        public decimal Value { get; private set; }
        public TransactionCategory TransactionCategory { get; private set; } = default!;
        public string Name { get; private set; } = default!;
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