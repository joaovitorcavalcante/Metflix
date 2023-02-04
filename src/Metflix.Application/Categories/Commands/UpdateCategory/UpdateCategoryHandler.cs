using MediatR;
using Metflix.Application.Common;
using Metflix.Domain.Entities;
using Metflix.Infraestructure.Persistence.Managers;

namespace Metflix.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler 
        : IRequestHandler<UpdateCategoryCommand, CommandResult<Category>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateCategoryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Task<CommandResult<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
