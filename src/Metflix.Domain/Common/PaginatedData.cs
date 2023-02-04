using Metflix.Domain.Abstractions;

namespace Metflix.Domain.Common
{
    public class PaginatedData<TEntity> where TEntity : EntityBase
    {
        public int TotalRecords { get; set; }
        public IEnumerable<TEntity> Data { get; set; }

        public PaginatedData(int totalRecords, IEnumerable<TEntity> data)
        {
            TotalRecords = totalRecords;
            Data = data;
        }
    }
}
