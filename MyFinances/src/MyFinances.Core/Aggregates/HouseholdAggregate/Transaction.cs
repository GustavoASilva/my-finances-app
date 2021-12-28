using Ardalis.GuardClauses;
using MyFinances.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.HouseholdAggregate
{
    public class Transaction : BaseEntity<Guid>
    {
        public Transaction(decimal value,
                           DateTime estimatedDate,
                           int transactionCategoryId)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            EstimatedDate = Guard.Against.Default(estimatedDate, nameof(EstimatedDate));
            TransactionCategoryId = transactionCategoryId;
        }

        public decimal Value { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }
        public int TransactionCategoryId { get; private set; }
        public int HouseholdId { get; private set; }

        public void Confirm()
        {
            if (ConfirmedDate != null) return;

            ConfirmedDate = DateTime.Now;
        }
    }
}