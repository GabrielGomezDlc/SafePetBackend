using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class VetResponse: BaseResponse<Vet>
{
    public VetResponse(string message) : base(message)
    {
    }

    public VetResponse(Vet resource) : base(resource)
    {
    }

}