using MediatR;

namespace MyFinances.Core
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; } = default!;

        private List<INotification> _domainEvents = new();
        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}