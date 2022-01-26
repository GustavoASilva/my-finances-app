using MyFinances.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.SyncedAggregates
{
    public class Origin : BaseEntity<int>, IAggregateRoot
    {
        public Origin()
        {
        }

        public Origin(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; private set; }
        public int HouseholdId { get;private set; }
    }
}
