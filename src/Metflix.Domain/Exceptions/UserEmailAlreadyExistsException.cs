using Metflix.Domain.Exceptions.Base;
using Metflix.Domain.Exceptions.Contracts;

namespace Metflix.Domain.Exceptions
{
    public class UserEmailAlreadyExistsException
        : ConflictException, IDomainException
    {
        public UserEmailAlreadyExistsException(string email)
            : base($"Email {email} already exists.")
        { }
    }
}
