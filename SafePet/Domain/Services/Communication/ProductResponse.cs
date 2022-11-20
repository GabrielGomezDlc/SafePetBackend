using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;

namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class ProductResponse: BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product resource) : base(resource)
    {
    }
}