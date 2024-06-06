using MediatR;

namespace Domain
{
    public abstract class Entity
    {
        public readonly List<INotification> _domainEvents = [];

        public List<INotification> PopDomainEvents()
        {
            var copy = _domainEvents.ToList();
            _domainEvents.Clear();

            return copy;
        }
    }
}
