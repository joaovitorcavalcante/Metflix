using MediatR;
using Metflix.Domain.Entities;
using Metflix.Domain.Exceptions;
using Metflix.Infraestructure.Persistence.Managers;
using Microsoft.EntityFrameworkCore;

namespace Metflix.Application.Categories.Commands.RemoveCategoryById
{
    public class RemoveCategoryByIdHandler 
        : IRequestHandler<RemoveCategoryByIdCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public RemoveCategoryByIdHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            if (await _repositoryManager.Category
                   .FindByCondition(c => c.Id == request.Id)
                   .SingleOrDefaultAsync() is not Category category)
            {
                throw new CategoryNotFoundException();
            }

            _repositoryManager.Category.Remove(category);
            await _repositoryManager.CommitAsync();

            return Unit.Value;
        }
    }
}
