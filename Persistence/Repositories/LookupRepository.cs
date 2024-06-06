using Application.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly ApplicationDbContext _context;

        public LookupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetCityList()
        {
            return await _context.Citiy.ToListAsync();
        }

        public async Task<List<Governorate>> GetGovernateList()
        {
            return await _context.Governorate.ToListAsync();
        }
    }
}