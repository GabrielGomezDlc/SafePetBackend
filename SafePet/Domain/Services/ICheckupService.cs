using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface ICheckupService
    {
        
        Task<IEnumerable<Checkup>> ListAsync();
        Task<CheckupResponse> SaveAsync(Checkup category);
        Task<CheckupResponse> UpdateAsync(int id, Checkup category);
        Task<CheckupResponse> DeleteAsync(int id);
        Task<Checkup> GetByIdAsync(int id);
    
    }
    
    
}

