using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IVeterinarianNearYouService
    {
        Task<IEnumerable<VeterinarianNearYou>> ListAsync();
        Task<VeterinarianNearYouResponse> SaveAsync(VeterinarianNearYou category);
        Task<VeterinarianNearYouResponse> UpdateAsync(int id, VeterinarianNearYou category);
        Task<VeterinarianNearYouResponse> DeleteAsync(int id);
        
        Task<VeterinarianNearYou> GetByIdAsync(int id);
    }
    
}

