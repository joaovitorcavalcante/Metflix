using Metflix.Domain.Abstractions;

namespace Metflix.Application.Common
{
    public class PaginatedQueryResult<TEntity> where TEntity : EntityBase
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
