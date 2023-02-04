using MediatR;

namespace Metflix.Application.Categories.Commands.RemoveCategoryById
{
    public class RemoveCategoryByIdCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public RemoveCategoryByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
