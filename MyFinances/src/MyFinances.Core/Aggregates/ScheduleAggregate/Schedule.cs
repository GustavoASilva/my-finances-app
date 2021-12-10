using MyFinances.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.ScheduleAggregate
{
    public class Schedule : BaseEntity<Guid>, IAggregateRoot
    {
        public int HouseholdId { get; set; }

        private readonly List<MoneyTransaction> _transactions = new();
        public IReadOnlyCollection<MoneyTransaction> Transactions => _transactions.AsReadOnly();

        public MoneyTransaction AddNewTransaction(MoneyTransaction transaction)
        {
            _transactions.Add(transaction);
            return transaction;
        }
    }
}
