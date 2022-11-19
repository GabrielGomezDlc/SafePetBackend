using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class AppointmentResponse: BaseResponse<Appointment>
{
    public AppointmentResponse(string message) : base(message)
    {
    }

    public AppointmentResponse(Appointment resource) : base(resource)
    {
    }
}