using Metflix.Domain.Common;
using Metflix.Domain.Entities;
using Metflix.Domain.Repositories;
using Metflix.Infraestructure.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Metflix.Infraestructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepositoryBase _repositoryBase;

        public CategoryRepository(IRepositoryBase repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(Category category)
        {
            await _repositoryBase.AddAsync<Category>(category);
        }

        public Task<PaginatedData<Category>> FindAllWithPagination(int pageNumber, int pageSize)
        {
            return _repositoryBase.FindAllWithPagination<Category>(pageNumber, pageSize);
        }

        public IQueryable<Category> FindByCondition(Expression<Func<Category, bool>> condition)
        {
            return _repositoryBase.FindByCondition<Category>(condition);
        }

        public void Remove(Category category)
        {
            _repositoryBase.Remove<Category>(category);
        }
    }
}
