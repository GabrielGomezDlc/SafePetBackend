using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IVetService
    {
        Task<IEnumerable<Vet>> ListAsync();
        Task<VetResponse> SaveAsync(Vet category);
        Task<VetResponse> UpdateAsync(int id, Vet category);
        Task<VetResponse> DeleteAsync(int id);
    }
    
}

