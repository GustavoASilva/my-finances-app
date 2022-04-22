using Ardalis.Specification;
using MyFinances.Core.SyncedAggregates;

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
