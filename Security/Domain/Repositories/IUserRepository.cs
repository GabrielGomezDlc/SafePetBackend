using SafePetBackend.Security.Domain.Models;

namespace SafePetBackend.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
    User FindById(int id);
    void Update(User user);
    void Remove(User user);
    User FindByEmail(string email);
   
    Task<User> FindByEmailAsync(string email);
}