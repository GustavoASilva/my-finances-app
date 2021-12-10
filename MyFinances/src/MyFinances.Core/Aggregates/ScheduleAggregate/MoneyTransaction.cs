using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates.ScheduleAggregate
{
    public class MoneyTransaction : BaseEntity<Guid>
    {
        public MoneyTransaction(decimal value, DateTime estimatedDate, bool isConfirmed, int categoryId)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            EstimatedDate = Guard.Against.Default(estimatedDate, nameof(EstimatedDate));
            IsConfirmed = isConfirmed;
            CategoryId = categoryId;
        }

        public decimal Value { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public DateTime ConfirmedDate { get; private set; }
        public bool IsConfirmed { get; private set; }
        public int CategoryId { get; private set; }

        public void Confirm()
        {
            if (IsConfirmed) return;

            ConfirmedDate = DateTime.Now;
            IsConfirmed = true;
        }
    }
}