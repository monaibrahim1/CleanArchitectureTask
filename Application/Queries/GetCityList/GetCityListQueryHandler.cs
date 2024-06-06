using Application.Interfaces.Repositories;

using AutoMapper;

using MediatR;

namespace Application.Queries
{
    public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, List<CityDto>>
    {
        private readonly IMapper _mapper;

        private readonly ILookupRepository _lookupRepository;

        public GetCityListQueryHandler(ILookupRepository lookupRepository, IMapper mapper)
        {
            _mapper = mapper;
            _lookupRepository = lookupRepository;
        }

        public async Task<List<CityDto>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
        {
            var cities = await _lookupRepository.GetCityList();

            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}
