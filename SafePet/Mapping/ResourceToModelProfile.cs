using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Resources;
using Profile = AutoMapper.Profile;

namespace SafePetBackend.SafePet.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAppointmentResource, Appointment>();
        CreateMap<SaveCheckupResource, Checkup>();
        CreateMap<SaveClientResource, Client>();
        CreateMap<SaveMostPurchasedProductResource, MostPurchasedProduct>();
        CreateMap<SaveProductResource, Product>();
        CreateMap<SaveProfileResource, SafePetBackend.SafePet.Domain.Models.Profile>();
        CreateMap<SaveReviewResource, Review>();
        CreateMap<SaveVetResource, Vet>();
        CreateMap<SaveVeterinarianNearYouResource, VeterinarianNearYou>();

    }
}


