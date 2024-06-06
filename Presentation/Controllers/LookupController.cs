using Application;
using Application.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LookupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("governorate")]
        public async Task<IEnumerable<GovernorateDto>> GetAsyncGovernates()
        {
            return await _mediator.Send(new GovernorateListQuery());
        }

        [HttpGet("city")]
        public async Task<IEnumerable<CityDto>> GetAsyncCities()
        {
            return await _mediator.Send(new GetCityListQuery());
        }

    }
}
