using FluentAssertions;
using MyFinances.Core.Exceptions;
using MyFinances.Core.SyncedAggregates;
using System;
using Xunit;

namespace MyFinances.UnitTests
{
    public class RecurrenceSpecs
    {
        [Fact]
        public void Monthly_type_recurrence_should_update_next_date_correctly()
        {
            var lastOccurrence = new DateTime(2022, 1, 1);

            var recurrence = new Recurrence(lastOccurrence, lastOccurrence, null, new Guid());

            recurrence.UpdateNextOccurrence();

            var expectedNextOcurrence = new DateTime(2022, 2, 1);

            recurrence.NextOccurrence
                .Should()
                .Be(expectedNextOcurrence);
        }

        [Fact]
        public void Recurrence_should_not_be_inactive_when_created()
        {
            var startDate = DateTime.Now;
            var recurrence = new Recurrence(startDate, startDate, null, new Guid());

            recurrence.IsActive
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Recurrence_should_throw_on_update_next_occurrence_when_inactive()
        {
            var lastOccurrence = new DateTime(2022, 1, 1);

            var recurrence = new Recurrence(lastOccurrence, lastOccurrence, null, new Guid());

            recurrence.SetIsActive(false);

            var updateAction = () =>  recurrence.UpdateNextOccurrence();

            updateAction
                .Should()
                .Throw<InactiveRecurrenceException>();
        }

    }
}