using Domain;

namespace Application.Interfaces.Repositories
{
    public interface ILookupRepository
    {
        Task<List<Governorate>> GetGovernateList();

        Task<List<City>> GetCityList();
    }
}
