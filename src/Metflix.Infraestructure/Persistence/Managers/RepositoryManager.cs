using Metflix.Domain.Abstractions;
using Metflix.Domain.Entities;
using Metflix.Domain.Repositories;
using Metflix.Infraestructure.Persistence.Repositories;

namespace Metflix.Infraestructure.Persistence.Managers
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly MetflixDbContext _context;

        private Lazy<ICategoryRepository> _categoryRepository;
        public ICategoryRepository Category => _categoryRepository.Value;

        public RepositoryManager(
            MetflixDbContext context,
            IRepositoryBase repositoryBase)
        {
            _context = context;
 
            _categoryRepository = new Lazy<ICategoryRepository>(
                () => new CategoryRepository(repositoryBase)); 
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
