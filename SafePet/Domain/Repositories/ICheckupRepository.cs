
using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface ICheckupRepository
{
    Task<IEnumerable<Checkup>> ListAsync();
    Task AddAsync(Checkup checkup);
    Task<Checkup> FindById(int id);
    void Update(Checkup checkup);
    void Remove(Checkup checkup);
}