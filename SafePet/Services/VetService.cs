using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class VetService: IVetService
{
    private readonly IVetRepository _vetRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VetService(IVetRepository vetRepository, IUnitOfWork unitOfWork)
    {
        _vetRepository = vetRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Vet>> ListAsync()
    {
        return await _vetRepository.ListAsync();
    }

    public async Task<VetResponse> SaveAsync(Vet vet)
    {
        try
        {
            await _vetRepository.AddAsync(vet);
            await _unitOfWork.CompleteAsync();
            return new VetResponse(vet);
        }
        catch (Exception e)
        {
            return new VetResponse($"An error occurred while saving the vet: {e.Message}");
        }
    }

    public async Task<VetResponse> UpdateAsync(int id, Vet birthday)
    {
        var existingVet = await _vetRepository.FindById(id);

        if (existingVet == null)
            return new VetResponse("Category not found.");

        existingVet.Birthday = birthday.Birthday;

        try
        {
            _vetRepository.Update(existingVet);
            await _unitOfWork.CompleteAsync();

            return new VetResponse(existingVet);
        }
        catch (Exception e)
        {
            return new VetResponse($"An error occurred while updating the bithday: {e.Message}");
        }
    }

    public async Task<VetResponse> DeleteAsync(int id)
    {
        var existingVet = await _vetRepository.FindById(id);

        if (existingVet == null)
            return new VetResponse("Date not found.");

        try
        {
            _vetRepository.Remove(existingVet);
            await _unitOfWork.CompleteAsync();

            return new VetResponse(existingVet);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new VetResponse($"An error occurred while deleting the birthday: {e.Message}");
        }
    }
}