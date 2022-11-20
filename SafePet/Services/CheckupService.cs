using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class CheckupService: ICheckupService
{
    private readonly ICheckupRepository _checkupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CheckupService(ICheckupRepository checkupRepository, IUnitOfWork unitOfWork)
    {
        _checkupRepository = checkupRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Checkup>> ListAsync()
    {
        return await _checkupRepository.ListAsync();
    }

    public async Task<CheckupResponse> SaveAsync(Checkup checkup)
    {
        try
        {
            await _checkupRepository.AddAsync(checkup);
            await _unitOfWork.CompleteAsync();
            return new CheckupResponse(checkup);
        }
        catch (Exception e)
        {
            return new CheckupResponse($"An error occurred while saving the date: {e.Message}");
        }
    }

    public async Task<CheckupResponse> UpdateAsync(int id, Checkup date)
    {
        var existingCheckup = await _checkupRepository.FindById(id);

        if (existingCheckup == null)
            return new CheckupResponse("Category not found.");

        existingCheckup.Date = date.Date;

        try
        {
            _checkupRepository.Update(existingCheckup);
            await _unitOfWork.CompleteAsync();

            return new CheckupResponse(existingCheckup);
        }
        catch (Exception e)
        {
            return new CheckupResponse($"An error occurred while updating the date: {e.Message}");
        }
    }

    public async Task<CheckupResponse> DeleteAsync(int id)
    {
        var existingCheckup = await _checkupRepository.FindById(id);

        if (existingCheckup == null)
            return new CheckupResponse("Date not found.");

        try
        {
            _checkupRepository.Remove(existingCheckup);
            await _unitOfWork.CompleteAsync();

            return new CheckupResponse(existingCheckup);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CheckupResponse($"An error occurred while deleting the date: {e.Message}");
        }
    }
}