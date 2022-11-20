using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IMostPurchasedProductService
    {
        Task<IEnumerable<MostPurchasedProduct>> ListAsync();
        Task<MostPurchasedProductResponse> SaveAsync(MostPurchasedProduct category);
        Task<MostPurchasedProductResponse> UpdateAsync(int id, MostPurchasedProduct category);
        Task<MostPurchasedProductResponse> DeleteAsync(int id);
    }
    
}

