using SafePetBackend.SafePet.Domain.Models;


namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindById(int id);
    void Update(Product product);
    void Remove(Product product);
}