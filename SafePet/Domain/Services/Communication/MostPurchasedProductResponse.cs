using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class MostPurchasedProductResponse: BaseResponse<MostPurchasedProduct>
{
    public MostPurchasedProductResponse(string message) : base(message)
    {
    }

    public MostPurchasedProductResponse(MostPurchasedProduct resource) : base(resource)
    {
    }

}