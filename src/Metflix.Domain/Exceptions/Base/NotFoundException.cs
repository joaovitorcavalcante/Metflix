namespace Metflix.Domain.Exceptions.Base
{
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base (message) { }
    }
}
