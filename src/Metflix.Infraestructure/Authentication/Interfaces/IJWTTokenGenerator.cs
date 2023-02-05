namespace Metflix.Infraestructure.Authentication.Interfaces
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(Guid userId);
    }
}
