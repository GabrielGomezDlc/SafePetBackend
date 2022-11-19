using SafePetBackend.Security.Domain.Models;

namespace SafePetBackend.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}