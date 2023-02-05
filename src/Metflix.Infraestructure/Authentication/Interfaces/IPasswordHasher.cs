namespace Metflix.Infraestructure.Authentication.Interfaces
{
    public interface IPasswordHasher
    {
        string GeneratePasswordHash(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
