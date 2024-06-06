using Application;
using Application.Commands;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<UserDto> Post([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(new CreateUserCommand(command.Firstname,
                command.Middlename, command.Lastname, command.BirthDate, command.Email,
                command.MobileNumber, command.Street, command.BuildingNumber, command.FlatNumber,
                command.HasAddress, command.CityId, command.GovernorateId));
        }
    }
}
