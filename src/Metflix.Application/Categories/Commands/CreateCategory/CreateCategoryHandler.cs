using MediatR;
using Metflix.Application.Common.Results;
using Metflix.Domain.Entities;
using Metflix.Domain.Exceptions;
using Metflix.Infraestructure.Persistence.Managers;

namespace Metflix.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler :
        IRequestHandler<CreateCategoryCommand, CommandResult<Category>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public CreateCategoryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<CommandResult<Category>> Handle(
            CreateCategoryCommand request, 
            CancellationToken cancellationToken)
        {
            if (_repositoryManager.Category.FindByCondition(
                c => c.Name == request.Name) is not null)
            {
                throw new CategoryNameAlreadyExistsException(request.Name);
            }

            var category = new Category(request.Name, request.Description);

            await _repositoryManager.Category.AddAsync(category);
            await _repositoryManager.CommitAsync();

            return new CommandResult<Category>(category);
        }
    }
}
