using AutoMapper;
using SafePetBackend.Security.Domain.Models;
using SafePetBackend.Security.Domain.Services.Communication;

namespace SafePetBackend.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();

        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
            ));
    }
}
