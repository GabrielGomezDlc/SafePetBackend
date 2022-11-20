using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> SaveAsync(Product category);
        Task<ProductResponse> UpdateAsync(int id, Product category);
        Task<ProductResponse> DeleteAsync(int id);
    }
}

