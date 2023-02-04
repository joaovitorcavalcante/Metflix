using MediatR;
using Metflix.Application.Common;
using Metflix.Domain.Entities;

namespace Metflix.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<QueryResult<Category>>
    {
        public Guid Id { get; set; }
        
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
