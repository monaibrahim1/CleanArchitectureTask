using Application.Interfaces.Repositories;

using AutoMapper;

using Domain;

using MediatR;

namespace Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = request.Firstname,
                MiddleName = request.Middlename,
                LastName = request.Lastname,
                BirthDate = request.BirthDate.Value,
                Email = request.Email,
                MobileNumber = request.MobileNumber
            };

            if(request.HasAddress)
            {
                user.AddAddress(request.Street, request.FlatNumber, request.BuildingNumber, request.CityId, request.GovernorateId);
            }

            user = await _userRepository.AddUser(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}
