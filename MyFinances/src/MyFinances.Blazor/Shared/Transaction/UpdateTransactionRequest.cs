using MyFinances.Core.SyncedAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Blazor.Shared.Transaction
{
    public class UpdateTransactionRequest
    {
        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public Category Category { get; set; }
        public int OriginId { get; set; }
        public string Description { get; set; }
        public bool Confirmed { get; set; }
    }
}
