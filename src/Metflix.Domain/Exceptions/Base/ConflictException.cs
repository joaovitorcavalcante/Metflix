namespace Metflix.Domain.Exceptions.Base
{
    public abstract class ConflictException : Exception
    {
        public ConflictException(string message)
            : base(message)
        { }
    }
}
