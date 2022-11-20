using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task<ProfileResponse> SaveAsync(Profile category);
        Task<ProfileResponse> UpdateAsync(int id, Profile category);
        Task<ProfileResponse> DeleteAsync(int id);
    }
    
}

