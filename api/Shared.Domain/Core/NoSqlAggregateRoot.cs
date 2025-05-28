namespace Shared.Domain.Core
{
    public class NoSqlAggregateRoot : NoSqlEntity
    {
        private readonly List<object> _domainEvents = new List<object>();
        public IReadOnlyList<object> DomainEvents => _domainEvents;

        public void AddDomainEvent<TEvent>(TEvent @event) where TEvent : class
        {
            _domainEvents.Add(@event);
        }
    }
}
