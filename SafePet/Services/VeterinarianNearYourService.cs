using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class VeterinarianNearYouService: IVeterinarianNearYouService
{
    private readonly IVeterinarianNearYouRepository _veterinarianNearYouRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VeterinarianNearYouService(IVeterinarianNearYouRepository veterinarianNearYouRepository, IUnitOfWork unitOfWork)
    {
        _veterinarianNearYouRepository = veterinarianNearYouRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<VeterinarianNearYou>> ListAsync()
    {
        return await _veterinarianNearYouRepository.ListAsync();
    }

    public async Task<VeterinarianNearYouResponse> SaveAsync(VeterinarianNearYou veterinarianNearYou)
    {
        try
        {
            await _veterinarianNearYouRepository.AddAsync(veterinarianNearYou);
            await _unitOfWork.CompleteAsync();
            return new VeterinarianNearYouResponse(veterinarianNearYou);
        }
        catch (Exception e)
        {
            return new VeterinarianNearYouResponse($"An error occurred while saving the date: {e.Message}");
        }
    }

    public async Task<VeterinarianNearYouResponse> UpdateAsync(int id, VeterinarianNearYou name)
    {
        var existingVeterinarianNearYou = await _veterinarianNearYouRepository.FindById(id);

        if (existingVeterinarianNearYou == null)
            return new VeterinarianNearYouResponse("Name not found.");

        existingVeterinarianNearYou.Name = name.Name;

        try
        {
            _veterinarianNearYouRepository.Update(existingVeterinarianNearYou);
            await _unitOfWork.CompleteAsync();

            return new VeterinarianNearYouResponse(existingVeterinarianNearYou);
        }
        catch (Exception e)
        {
            return new VeterinarianNearYouResponse($"An error occurred while updating the name: {e.Message}");
        }
    }

    public async Task<VeterinarianNearYouResponse> DeleteAsync(int id)
    {
        var existingVeterinarianNearYou = await _veterinarianNearYouRepository.FindById(id);

        if (existingVeterinarianNearYou == null)
            return new VeterinarianNearYouResponse("Name not found.");

        try
        {
            _veterinarianNearYouRepository.Remove(existingVeterinarianNearYou);
            await _unitOfWork.CompleteAsync();

            return new VeterinarianNearYouResponse(existingVeterinarianNearYou);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new VeterinarianNearYouResponse($"An error occurred while deleting the name: {e.Message}");
        }
    }
    
    public async Task<VeterinarianNearYou> GetByIdAsync(int id)
    {
        var user = await _veterinarianNearYouRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("VeterinarianNearYou not found");
        return user;
    }
}