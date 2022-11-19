using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IVetRepository
{
    Task<IEnumerable<Vet>> ListAsync();
    Task AddAsync(Vet vet);
    Task<Vet> FindById(int id);
    void Update(Vet vet);
    void Remove(Vet vet);
}