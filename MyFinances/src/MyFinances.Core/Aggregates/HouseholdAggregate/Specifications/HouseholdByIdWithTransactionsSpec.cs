using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.HouseholdAggregate.Specifications
{
    public class HouseholdByIdWithTransactionsSpec : Specification<Household>, ISingleResultSpecification
    {
        public HouseholdByIdWithTransactionsSpec(int householdId)
        {
            Query
                .Where(household => household.Id == householdId)
                .Include(household => household.Transactions);
        }
    }
}
