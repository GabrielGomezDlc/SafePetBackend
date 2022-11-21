using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> ListAsync();
    Task AddAsync(Client client);
    Task<Client> FindById(int id);
    Task<Client> FindByVetId(int vetId);
    void Update(Client client);
    void Remove(Client client);
}