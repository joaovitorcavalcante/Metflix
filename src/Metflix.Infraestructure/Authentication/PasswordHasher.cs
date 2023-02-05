using BCrypt;
using Metflix.Infraestructure.Authentication.Interfaces;

namespace Metflix.Infraestructure.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GeneratePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
