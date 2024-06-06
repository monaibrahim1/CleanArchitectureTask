using MediatR;

namespace Application.Queries
{
    public class GovernorateListQuery : IRequest<List<GovernorateDto>>
    {
    }
}
