using Application.Interfaces.Repositories;
using Domain;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _context.Set<User>().AddAsync(user);

            await _context.SaveChangesAsync();

            return new User()
            {
                FirstName = result.Entity.FirstName,
                MiddleName = result.Entity.MiddleName,
                LastName = result.Entity.LastName,
                Email = result.Entity.Email,
                BirthDate = result.Entity.BirthDate,
                MobileNumber = result.Entity.MobileNumber,
                Id = result.Entity.Id,
            };
        }
    }
}
