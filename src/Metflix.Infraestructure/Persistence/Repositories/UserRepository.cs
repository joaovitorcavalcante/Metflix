using Metflix.Domain.Entities;
using Metflix.Domain.Repositories;
using Metflix.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Metflix.Infraestructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepositoryBase _repositoryBase;

        public UserRepository(IRepositoryBase repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(User user)
        {
            await _repositoryBase.AddAsync<User>(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _repositoryBase
                .FindByCondition<User>(u => u.Email == email)
                .SingleOrDefaultAsync();
        }
    }
}
