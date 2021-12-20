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

        private readonly List<Transaction> _transactions = new();
        public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

        public List<Transaction> AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);

            if(transaction.Recurrence != null)
            {
                DateTime nextInsertDate;
                do
                {
                    nextInsertDate = transaction.EstimatedDate.AddDays(transaction.Recurrence.DaysInterval);
                    var newTransaction = new Transaction(transaction.Value, nextInsertDate, false, transaction.CategoryId);
                    _transactions.Add(newTransaction);
                }
                while (nextInsertDate <= transaction.Recurrence.InsertUntil);
            }

            return _transactions;
        }
    }
}
