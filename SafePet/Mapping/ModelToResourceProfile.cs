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
        CreateMap<Checkup, CheckupResource>();
        CreateMap<Client, ClientResource>();
        CreateMap<MostPurchasedProduct, MostPurchasedProductResource>();
        CreateMap<Product, ProductResource>();
        CreateMap<SafePetBackend.SafePet.Domain.Models.Profile, ProfileResource>();
        CreateMap<Review, ReviewResource>();
        CreateMap<Vet, VetResource>();
        CreateMap<VeterinarianNearYou, VeterinarianNearYouResource>();
    }
}


