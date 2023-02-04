using MediatR;
using Metflix.Application.Common;
using Metflix.Domain.Entities;
using Metflix.Infraestructure.Persistence.Managers;
using Microsoft.EntityFrameworkCore;

namespace Metflix.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler 
        : IRequestHandler<GetCategoryByIdQuery, QueryResult<Category>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetCategoryByIdHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<QueryResult<Category>> Handle(
            GetCategoryByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var category = await _repositoryManager.Category
                .FindByCondition(c => c.Id == request.Id)
                .SingleOrDefaultAsync();

            return new QueryResult<Category>(category);
        }
    }
}
