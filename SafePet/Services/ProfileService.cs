using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class ProfileService: IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Profile>> ListAsync()
    {
        return await _profileRepository.ListAsync();
    }

    public async Task<ProfileResponse> SaveAsync(Profile profile)
    {
        try
        {
            await _profileRepository.AddAsync(profile);
            await _unitOfWork.CompleteAsync();
            return new ProfileResponse(profile);
        }
        catch (Exception e)
        {
            return new ProfileResponse($"An error occurred while saving the profile: {e.Message}");
        }
    }

    public async Task<ProfileResponse> UpdateAsync(int id, Profile birthday)
    {
        var existingProfile = await _profileRepository.FindById(id);

        if (existingProfile == null)
            return new ProfileResponse("Category not found.");

        existingProfile.Birthday= birthday.Birthday;

        try
        {
            _profileRepository.Update(existingProfile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(existingProfile);
        }
        catch (Exception e)
        {
            return new ProfileResponse($"An error occurred while updating the birthday: {e.Message}");
        }
    }

    public async Task<ProfileResponse> DeleteAsync(int id)
    {
        var existingProfile = await _profileRepository.FindById(id);

        if (existingProfile == null)
            return new ProfileResponse("Birthday not found.");

        try
        {
            _profileRepository.Remove(existingProfile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(existingProfile);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ProfileResponse($"An error occurred while deleting the date: {e.Message}");
        }
    }
}