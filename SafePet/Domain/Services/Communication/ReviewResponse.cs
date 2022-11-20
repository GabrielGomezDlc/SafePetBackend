using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class ReviewResponse: BaseResponse<Review>
{
    public ReviewResponse(string message) : base(message)
    {
    }

    public ReviewResponse(Review resource) : base(resource)
    {
    }

}