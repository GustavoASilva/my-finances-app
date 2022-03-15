using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Blazor.Shared.Transaction
{
    public class PatchTransactionRequest
    {
        public bool Confirmed { get; set; }

        public PatchTransactionRequest()
        {
        }

        public PatchTransactionRequest(bool confirmed)
        {
            Confirmed = confirmed;
        }
    }
}
