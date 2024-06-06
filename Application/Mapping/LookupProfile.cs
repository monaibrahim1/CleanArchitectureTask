using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class LookupProfile : Profile
    {
        public LookupProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<Governorate, GovernorateDto>();
        }
    }
}
