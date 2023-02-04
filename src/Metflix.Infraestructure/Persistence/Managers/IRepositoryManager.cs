using Metflix.Domain.Repositories;

namespace Metflix.Infraestructure.Persistence.Managers
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }

        Task CommitAsync();
    }
}
