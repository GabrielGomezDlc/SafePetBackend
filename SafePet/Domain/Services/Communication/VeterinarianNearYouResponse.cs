using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class VeterinarianNearYouResponse: BaseResponse<VeterinarianNearYou>
{
    public VeterinarianNearYouResponse(string message) : base(message)
    {
    }

    public VeterinarianNearYouResponse(VeterinarianNearYou resource) : base(resource)
    {
    }

}