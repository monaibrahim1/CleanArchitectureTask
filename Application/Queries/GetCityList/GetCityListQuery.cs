using MediatR;

namespace Application.Queries
{
    public class GetCityListQuery : IRequest<List<CityDto>>
    {
    }
}
