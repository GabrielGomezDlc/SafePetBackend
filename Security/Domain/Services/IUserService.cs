using SafePetBackend.Security.Domain.Models;
using SafePetBackend.Security.Domain.Services.Communication;

namespace SafePetBackend.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);
}
