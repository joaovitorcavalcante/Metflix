using MediatR;
using Metflix.Application.Common.Results;
using Metflix.Domain.Entities;

namespace Metflix.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<PaginatedQueryResult<Category>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllCategoriesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
