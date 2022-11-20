using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<AppointmentResponse> SaveAsync(Appointment category);
        Task<AppointmentResponse> UpdateAsync(int id, Appointment category);
        Task<AppointmentResponse> DeleteAsync(int id);
        
        
    }
}