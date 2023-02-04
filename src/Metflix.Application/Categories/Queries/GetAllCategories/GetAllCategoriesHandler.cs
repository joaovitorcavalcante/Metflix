using MediatR;
using Metflix.Application.Common;
using Metflix.Domain.Entities;
using Metflix.Infraestructure.Persistence.Managers;

namespace Metflix.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler 
        : IRequestHandler<GetAllCategoriesQuery, PaginatedQueryResult<Category>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetAllCategoriesHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PaginatedQueryResult<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var paginatedCategories = await _repositoryManager.Category.FindAllWithPagination(request.PageNumber, request.PageSize);
            var totalPages = (int)Math.Ceiling((double)paginatedCategories.TotalRecords / (double)request.PageSize);

            return new PaginatedQueryResult<Category>
            { 
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Data = paginatedCategories.Data,
                TotalRecords = paginatedCategories.TotalRecords,
                TotalPages = totalPages
            };
        }
    }
}
