using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Shared.Transaction
{
    public class CreateTransactionRequest
    {
        public CreateTransactionRequest()
        {
        }

        public string Description { get; set; }

        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public Category Category { get; set; }

        public int InstallmentsNumber { get; set; }

        public int OriginId { get; set; }
    }
}
