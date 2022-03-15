using Ardalis.Specification;
using MyFinances.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.TransactionAggregate.Specification
{
    public class TransactionFilterSpec : Specification<Transaction>
    {
        public TransactionFilterSpec(DateTime? estimatedDateStart, DateTime? estimatedDateEnd)
        {
            Query.
                Where(t => (!estimatedDateStart.HasValue
                            || t.EstimatedDate >= estimatedDateStart)
                           && (!estimatedDateEnd.HasValue ||
                           t.EstimatedDate <= estimatedDateEnd));
        }
    }
}
