using Domain;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
    }
}
