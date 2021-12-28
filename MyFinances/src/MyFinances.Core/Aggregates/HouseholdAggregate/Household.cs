using MyFinances.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.HouseholdAggregate
{
    public class Household : BaseEntity<int>, IAggregateRoot
    {
        private List<Transaction> _transactions = new List<Transaction>();
        public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();

        public Transaction AddNewTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            return transaction;
        }
    }
}
