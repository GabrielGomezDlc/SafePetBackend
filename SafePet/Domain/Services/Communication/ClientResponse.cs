using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services.Communication;

public class ClientResponse: BaseResponse<Client>
{
    public ClientResponse(string message) : base(message)
    {
    }

    public ClientResponse(Client resource) : base(resource)
    {
    }
}