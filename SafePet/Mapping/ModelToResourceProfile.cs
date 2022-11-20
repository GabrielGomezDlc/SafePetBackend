using AutoMapper;
using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Resources;
using Profile = AutoMapper.Profile;


namespace SafePetBackend.SafePet.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Appointment, AppointmentResource>();
        
    }
}


