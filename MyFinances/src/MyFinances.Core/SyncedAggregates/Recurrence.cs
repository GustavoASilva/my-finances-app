using MyFinances.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.SyncedAggregates
{
    public class Recurrence : BaseEntity<Guid>, IAggregateRoot
    {
        public DateTime StartDate { get; private set; }
        public bool IsActive { get; private set; }

        public DateTime? LatestOccurrence { get; private set; }
        public DateTime? NextOccurrence { get; private set; }
        public RecurrenceType Type { get; private set; }
        public Guid TransactionId { get; private set; }
    }
}
