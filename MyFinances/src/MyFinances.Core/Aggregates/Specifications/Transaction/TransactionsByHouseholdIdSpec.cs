using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.Specifications
{
    public class TransactionsByHouseholdIdSpec : Specification<Transaction>
    {
        public TransactionsByHouseholdIdSpec(int householdId)
        {
            Query.
                Where(t => t.HouseholdId == householdId);
        }
    }
}
