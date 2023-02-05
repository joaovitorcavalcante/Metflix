using Metflix.Domain.Abstractions;
using Metflix.Domain.Common;
using Metflix.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Metflix.Infraestructure.Persistence.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly MetflixDbContext _context;

        public RepositoryBase(MetflixDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : EntityBase
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<PaginatedData<TEntity>> FindAllWithPagination<TEntity>(int pageNumber, int pageSize)
            where TEntity : EntityBase
        {
            var totalRecords = await _context.Set<TEntity>().CountAsync();

            var data = _context.Set<TEntity>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();

            return new PaginatedData<TEntity>(totalRecords, data);
        }

        public IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> condition)
            where TEntity : EntityBase
        {
            return _context.Set<TEntity>().Where(condition).AsNoTracking();
        }

        public void Remove<TEntity>(TEntity entity)
            where TEntity : EntityBase
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update<TEntity>(TEntity entity)
            where TEntity : EntityBase
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
