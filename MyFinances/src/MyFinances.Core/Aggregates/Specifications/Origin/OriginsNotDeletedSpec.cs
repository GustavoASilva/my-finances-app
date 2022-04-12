using Ardalis.Specification;
using MyFinances.Core.SyncedAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.Specifications
{
    public class OriginsNotDeletedSpec : Specification<Origin>
    {
        public OriginsNotDeletedSpec()
        {
            Query.
                Where(o => o.DeletedAt == null);
        }
    }
}
