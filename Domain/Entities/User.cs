using MediatR;

namespace Domain
{
    public class User : Entity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public required string Email { get; set; }

        public string MobileNumber { get; set; }

        public int? GovernorateId { get; set; }

        public int? CityId { get; set; }

        public string BuildingNumber { get; set; }

        public string FlatNumber { get; set; }

        public string Street { get; set; }

        public Governorate Governorate { get; set; }

        public City City { get; set; }

        public void AddAddress(string street, string flatNumber, string buildingNumber, int? cityId, int? governorateId)
        {
            ArgumentException.ThrowIfNullOrEmpty(street, nameof(street));
            ArgumentException.ThrowIfNullOrEmpty(flatNumber, nameof(flatNumber));
            ArgumentException.ThrowIfNullOrEmpty(buildingNumber, nameof(buildingNumber));

            Street = street;
            FlatNumber = flatNumber;
            BuildingNumber = buildingNumber;
            CityId = cityId;
            GovernorateId = governorateId;

            _domainEvents.Add(new OnUserAddressAddedEvent(governorateId.Value));
        }
    }
}