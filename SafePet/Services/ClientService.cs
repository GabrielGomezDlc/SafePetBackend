using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class ClientService: IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _clientRepository.ListAsync();
    }

    public async Task<ClientResponse> SaveAsync(Client client)
    {
        try
        {
            await _clientRepository.AddAsync(client);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(client);
        }
        catch (Exception e)
        {
            return new ClientResponse($"An error occurred while saving the date: {e.Message}");
        }
    }

    public async Task<ClientResponse> UpdateAsync(int id, Client petName)
    {
        var existingClient = await _clientRepository.FindById(id);

        if (existingClient == null)
            return new ClientResponse("Category not found.");

        existingClient.PetName = petName.PetName;

        try
        {
            _clientRepository.Update(existingClient);
            await _unitOfWork.CompleteAsync();

            return new ClientResponse(existingClient);
        }
        catch (Exception e)
        {
            return new ClientResponse($"An error occurred while updating the date: {e.Message}");
        }
    }

    public async Task<ClientResponse> DeleteAsync(int id)
    {
        var existingClient = await _clientRepository.FindById(id);

        if (existingClient == null)
            return new ClientResponse("PetName not found.");

        try
        {
            _clientRepository.Remove(existingClient);
            await _unitOfWork.CompleteAsync();

            return new ClientResponse(existingClient);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ClientResponse($"An error occurred while deleting the date: {e.Message}");
        }
    }
}