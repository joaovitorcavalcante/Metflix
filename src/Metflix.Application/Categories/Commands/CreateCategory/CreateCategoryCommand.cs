using MediatR;
using Metflix.Application.Common;
using Metflix.Domain.Entities;

namespace Metflix.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CommandResult<Category>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
