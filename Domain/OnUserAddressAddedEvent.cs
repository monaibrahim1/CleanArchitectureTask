using MediatR;

namespace Domain;

public record OnUserAddressAddedEvent(int GovernorateId) : INotification;