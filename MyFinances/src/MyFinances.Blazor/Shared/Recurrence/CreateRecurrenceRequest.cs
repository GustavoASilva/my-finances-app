using MyFinances.Core.SyncedAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Blazor.Shared.Recurrence
{
    public class CreateRecurrenceRequest
    {
        public DateOnly StartDate { get; private set; }
        public int DaysInterval { get; private set; }
        public decimal Value { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public int OriginId { get; private set; }
        public bool IsActive { get; private set; }
        public DateOnly NextOccurrenceDate { get; private set; }
    }
}