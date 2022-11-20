using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class MostPurchasedProductService: IMostPurchasedProductService
{
    private readonly IMostPurchasedProductRepository _mostPurchasedProductRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MostPurchasedProductService(IMostPurchasedProductRepository mostPurchasedProductRepository, IUnitOfWork unitOfWork)
    {
        _mostPurchasedProductRepository = mostPurchasedProductRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MostPurchasedProduct>> ListAsync()
    {
        return await _mostPurchasedProductRepository.ListAsync();
    }

    public async Task<MostPurchasedProductResponse> SaveAsync(MostPurchasedProduct mostPurchasedProduct)
    {
        try
        {
            await _mostPurchasedProductRepository.AddAsync(mostPurchasedProduct);
            await _unitOfWork.CompleteAsync();
            return new MostPurchasedProductResponse(mostPurchasedProduct);
        }
        catch (Exception e)
        {
            return new MostPurchasedProductResponse($"An error occurred while saving the date: {e.Message}");
        }
    }

    public async Task<MostPurchasedProductResponse> UpdateAsync(int id, MostPurchasedProduct name)
    {
        var existingMostPurchasedProduct = await _mostPurchasedProductRepository.FindById(id);

        if (existingMostPurchasedProduct == null)
            return new MostPurchasedProductResponse("Category not found.");

        existingMostPurchasedProduct.Name = name.Name;

        try
        {
            _mostPurchasedProductRepository.Update(existingMostPurchasedProduct);
            await _unitOfWork.CompleteAsync();

            return new MostPurchasedProductResponse(existingMostPurchasedProduct);
        }
        catch (Exception e)
        {
            return new MostPurchasedProductResponse($"An error occurred while updating the date: {e.Message}");
        }
    }

    public async Task<MostPurchasedProductResponse> DeleteAsync(int id)
    {
        var existingMostPurchasedProduct = await _mostPurchasedProductRepository.FindById(id);

        if (existingMostPurchasedProduct == null)
            return new MostPurchasedProductResponse("Date not found.");

        try
        {
            _mostPurchasedProductRepository.Remove(existingMostPurchasedProduct);
            await _unitOfWork.CompleteAsync();

            return new MostPurchasedProductResponse(existingMostPurchasedProduct);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new MostPurchasedProductResponse($"An error occurred while deleting the Name: {e.Message}");
        }
    }
}