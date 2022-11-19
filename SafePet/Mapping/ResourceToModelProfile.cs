using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Resources;
using Profile = AutoMapper.Profile;

namespace SafePetBackend.SafePet.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAppointmentResource, Appointment>();
        

    }
}


