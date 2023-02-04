using Metflix.Domain.Exceptions.Base;
using Metflix.Domain.Exceptions.Contracts;

namespace Metflix.Domain.Exceptions
{
    public class CategoryNotFoundException
        : NotFoundException, IDomainException
    {
        public CategoryNotFoundException()
            : base($"Category not found.")
        { }

        public CategoryNotFoundException(string name) 
            : base($"Category {name} not found.")
        { }
    }
}
