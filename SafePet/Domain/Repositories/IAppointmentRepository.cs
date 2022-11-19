using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task AddAsync(Appointment appointment);
    Task<Appointment> FindById(int id);
    void Update(Appointment appointment);
    void Remove(Appointment appointment);
}