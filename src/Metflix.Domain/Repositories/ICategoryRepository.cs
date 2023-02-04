using Metflix.Domain.Abstractions;
using Metflix.Domain.Common;
using Metflix.Domain.Entities;
using System.Linq.Expressions;

namespace Metflix.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<PaginatedData<Category>> FindAllWithPagination(int pageNumber, int pageSize);
        IQueryable<Category> FindByCondition(Expression<Func<Category, bool>> condition);
        void Remove(Category category);
    }
}
