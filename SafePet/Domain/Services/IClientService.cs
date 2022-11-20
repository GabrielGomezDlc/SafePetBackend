using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<ClientResponse> SaveAsync(Client category);
        Task<ClientResponse> UpdateAsync(int id, Client category);
        Task<ClientResponse> DeleteAsync(int id);
    }
    
}

