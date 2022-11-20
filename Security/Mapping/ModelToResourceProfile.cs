using AutoMapper;
using SafePetBackend.Security.Domain.Models;
using SafePetBackend.Security.Domain.Services.Communication;
using SafePetBackend.Security.Resources;

namespace SafePetBackend.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();

        CreateMap<User, UserResource>();
    }
}