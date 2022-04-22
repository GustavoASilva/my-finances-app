using Ardalis.Specification;

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
                           t.EstimatedDate <= estimatedDateEnd))
                .Include(x => x.Category);
        }
    }
}
