using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public bool HasAddress { get; set; }

        public int? GovernorateId { get; set; }

        public int? CityId { get; set; }

        public string BuildingNumber { get; set; }

        public string FlatNumber { get; set; }

        public string Street { get; set; }

        public CreateUserCommand(string firstName, string middleName, string lastName, DateTime? birthDate,
            string email, string mobileNumber, string street, string buildingNumber, string flatNumber, bool hasAddress, int? cityId, int? governorateId)
        {
            Firstname = firstName;
            Lastname = lastName;
            Email = email;
            MobileNumber = mobileNumber;
            Middlename = middleName;
            BirthDate = birthDate;

            HasAddress = hasAddress;
            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;

            CityId = cityId;
            GovernorateId = governorateId;
        }
    }
}
