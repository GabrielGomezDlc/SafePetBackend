using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IMostPurchasedProductRepository
{
    Task<IEnumerable<MostPurchasedProduct>> ListAsync();
    Task AddAsync(MostPurchasedProduct checkup);
    Task<MostPurchasedProduct> FindById(int id);
    void Update(MostPurchasedProduct mostPurchasedProduct);
    void Remove(MostPurchasedProduct mostPurchasedProduct);
}