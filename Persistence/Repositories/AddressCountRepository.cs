using Application.Interfaces.Repositories;

using Domain;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class AddressCountRepository : IAddressCountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressCountRepository(ApplicationDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _dbContext = dbContext;
        }

        public async Task UpdateCount(int GovernorateId)
        {
            var addressCount = await _dbContext.AddressCount.FirstOrDefaultAsync(e => e.Id == GovernorateId);

            if (addressCount == null)
            {
                var newAddressCount = new AddressCount()
                {
                    Id = GovernorateId,
                    Count = 1
                };

                _dbContext.AddressCount.Add(newAddressCount);
            }
            else
            {
                addressCount.Count += 1;
                _dbContext.Update(addressCount);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
