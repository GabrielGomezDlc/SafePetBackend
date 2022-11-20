using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class ProfileResponse: BaseResponse<Profile>
{
    public ProfileResponse(string message) : base(message)
    {
    }

    public ProfileResponse(Profile resource) : base(resource)
    {
    }

}