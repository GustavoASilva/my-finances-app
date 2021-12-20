using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.ScheduleAggregate
{
    public class Recurrence : ValueObject
    {
        public int DaysInterval { get; set; }
        public DateTime InsertUntil { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}