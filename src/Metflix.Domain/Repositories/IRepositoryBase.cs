using Metflix.Domain.Abstractions;
using Metflix.Domain.Common;
using System.Linq.Expressions;

namespace Metflix.Domain.Repositories
{
    public interface IRepositoryBase
    {
        Task AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task<PaginatedData<TEntity>> FindAllWithPagination<TEntity>(int pageNumber, int pageSize) where TEntity : EntityBase;
        IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : EntityBase;
        void Remove<TEntity>(TEntity entity) where TEntity : EntityBase;
        void Update<TEntity>(TEntity entity) where TEntity : EntityBase;
    }
}