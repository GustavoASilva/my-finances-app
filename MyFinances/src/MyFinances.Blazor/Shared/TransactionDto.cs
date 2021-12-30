using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Blazor.Shared
{
    public class TransactionDto
    {
        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
    }
}
