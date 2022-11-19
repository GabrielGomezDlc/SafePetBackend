using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class AppointmentService: IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Appointment>> ListAsync()
    {
        return await _appointmentRepository.ListAsync();
    }

    public async Task<AppointmentResponse> SaveAsync(Appointment appointment)
    {
        try
        {
            await _appointmentRepository.AddAsync(appointment);
            await _unitOfWork.CompleteAsync();
            return new AppointmentResponse(appointment);
        }
        catch (Exception e)
        {
            return new AppointmentResponse($"An error occurred while saving the date: {e.Message}");
        }
    }

    public async Task<AppointmentResponse> UpdateAsync(int id, Appointment date)
    {
        var existingAppointment = await _appointmentRepository.FindById(id);

        if (existingAppointment == null)
            return new AppointmentResponse("Category not found.");

        existingAppointment.Date = date.Date;

        try
        {
            _appointmentRepository.Update(existingAppointment);
            await _unitOfWork.CompleteAsync();

            return new AppointmentResponse(existingAppointment);
        }
        catch (Exception e)
        {
            return new AppointmentResponse($"An error occurred while updating the date: {e.Message}");
        }
    }

    public async Task<AppointmentResponse> DeleteAsync(int id)
    {
        var existingAppointment = await _appointmentRepository.FindById(id);

        if (existingAppointment == null)
            return new AppointmentResponse("Date not found.");

        try
        {
            _appointmentRepository.Remove(existingAppointment);
            await _unitOfWork.CompleteAsync();

            return new AppointmentResponse(existingAppointment);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new AppointmentResponse($"An error occurred while deleting the date: {e.Message}");
        }
    }
}