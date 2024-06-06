using Application.Interfaces.Repositories;

using Domain;

using MediatR;

namespace Application.Events
{
    public class OnUserAddressAddedEventHandler(IAddressCountRepository addressCountRepository) : INotificationHandler<OnUserAddressAddedEvent>
    {
        private readonly IAddressCountRepository _addressCountRepository = addressCountRepository;

        public async Task Handle(OnUserAddressAddedEvent notification, CancellationToken cancellationToken)
        {
            await _addressCountRepository.UpdateCount(notification.GovernorateId);
        }
    }
}
