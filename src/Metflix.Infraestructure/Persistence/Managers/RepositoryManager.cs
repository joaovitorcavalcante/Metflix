using Metflix.Domain.Repositories;
using Metflix.Infraestructure.Persistence.Repositories;
using Metflix.Infraestructure.Persistence.Repositories.Interfaces;

namespace Metflix.Infraestructure.Persistence.Managers
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly MetflixDbContext _context;

        private Lazy<ICategoryRepository> _categoryRepository;
        private Lazy<IUserRepository> _userRepository;

        public ICategoryRepository Category => _categoryRepository.Value;
        public IUserRepository User => _userRepository.Value;

        public RepositoryManager(
            MetflixDbContext context,
            IRepositoryBase repositoryBase)
        {
            _context = context;
 
            _categoryRepository = new Lazy<ICategoryRepository>(
                () => new CategoryRepository(repositoryBase));

            _userRepository = new Lazy<IUserRepository>(
                () => new UserRepository(repositoryBase));
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
