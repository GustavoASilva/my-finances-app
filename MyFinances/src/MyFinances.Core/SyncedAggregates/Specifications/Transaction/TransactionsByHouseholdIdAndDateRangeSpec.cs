using Ardalis.Specification;
using MyFinances.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.SyncedAggregates.Specifications
{
    public class TransactionsByHouseholdIdAndDateRangeSpec : Specification<Transaction>
    {
        public TransactionsByHouseholdIdAndDateRangeSpec(int householdId, DateTimeRange dateRange)
        {
            Query.
               Where(t => t.HouseholdId == householdId && t.EstimatedDate > dateRange.Start && t.EstimatedDate < dateRange.End);
        }
    }
}
