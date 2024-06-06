using Application.Interfaces.Repositories;

using AutoMapper;

using MediatR;

namespace Application.Queries
{
    public class GovernorateListQueryHandler : IRequestHandler<GovernorateListQuery, List<GovernorateDto>>
    {
        private readonly IMapper _mapper;

        private readonly ILookupRepository _lookupRepository;

        public GovernorateListQueryHandler(ILookupRepository lookupRepository, IMapper mapper)
        {
            _mapper = mapper;
            _lookupRepository = lookupRepository;
        }

        public async Task<List<GovernorateDto>> Handle(GovernorateListQuery request, CancellationToken cancellationToken)
        {
            var governates = await _lookupRepository.GetGovernateList();

            return _mapper.Map<List<GovernorateDto>>(governates);
        }
    }
}
