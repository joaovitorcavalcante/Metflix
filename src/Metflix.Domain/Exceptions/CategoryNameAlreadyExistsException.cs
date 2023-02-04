using Metflix.Domain.Exceptions.Base;
using Metflix.Domain.Exceptions.Contracts;

namespace Metflix.Domain.Exceptions
{
    public class CategoryNameAlreadyExistsException 
        : ConflictException, IDomainException
    {
        public CategoryNameAlreadyExistsException(string name)
            : base($"Name {name} category already exists.")
        { }
    }
}
