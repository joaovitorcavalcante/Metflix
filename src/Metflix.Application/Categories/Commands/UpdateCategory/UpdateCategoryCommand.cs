using MediatR;
using Metflix.Application.Common;
using Metflix.Domain.Entities;

namespace Metflix.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand 
        : IRequest<CommandResult<Category>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
