using Metflix.Domain.Entities;

namespace Metflix.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> FindByEmailAsync(string email);
    }
}
