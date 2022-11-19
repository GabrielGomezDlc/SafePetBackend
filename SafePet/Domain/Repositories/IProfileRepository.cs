using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IProfileRepository
{
    Task<IEnumerable<Profile>> ListAsync();
    Task AddAsync(Profile profile);
    Task<Profile> FindById(int id);
    void Update(Profile profile);
    void Remove(Profile profile);
}