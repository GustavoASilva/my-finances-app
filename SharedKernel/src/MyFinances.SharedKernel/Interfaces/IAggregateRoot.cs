using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.SharedKernel.Interfaces
{
    /// <summary>
    /// Marker for aggregate roots. Repositories should work only with an aggregate
    /// </summary>
    public interface IAggregateRoot { }
}
