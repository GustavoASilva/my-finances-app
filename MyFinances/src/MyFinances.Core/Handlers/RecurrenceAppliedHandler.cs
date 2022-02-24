using MediatR;
using MyFinances.Core.Events;
using MyFinances.Core.Interfaces;
using MyFinances.Core.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Handlers
{
    public class RecurrenceAppliedHandler : INotificationHandler<RecurrenceAppliedDomainEvent>
    {
        private readonly IRepository<Transaction> _repository;

        public RecurrenceAppliedHandler(IRepository<Transaction> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(RecurrenceAppliedDomainEvent notification, CancellationToken cancellationToken)
        {
            TimeOnly midnight = TimeOnly.MinValue;
            var description = $"Transação recorrente: {notification.Name}";

            var transaction = new Transaction(notification.Value, notification.Category, notification.HouseholdId,notification.OriginId, description, notification.EstimatedTransactionDate.ToDateTime(midnight));
            await _repository.AddAsync(transaction, cancellationToken);
        }
    }
}