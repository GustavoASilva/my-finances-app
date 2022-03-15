using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Blazor.Shared.Origin
{
    public class CreateOriginRequest
    {
        public CreateOriginRequest(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; set; }
    }
}
