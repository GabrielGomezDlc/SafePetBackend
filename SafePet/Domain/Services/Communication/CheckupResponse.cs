using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class CheckupResponse: BaseResponse<Checkup>
{
    public CheckupResponse(string message) : base(message)
    {
    }

    public CheckupResponse(Checkup resource) : base(resource)
    {
    }
}