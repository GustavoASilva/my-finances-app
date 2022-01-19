using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Shared
{
    public class CreateTransactionRequest
    {
        public CreateTransactionRequest()
        {
        }

        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public Category Category { get; set; }
    }
}
