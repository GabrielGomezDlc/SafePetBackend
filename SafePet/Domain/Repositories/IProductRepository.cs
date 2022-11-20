using SafePetBackend.SafePet.Domain.Models;


namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindById(int id);
    Task<Product> FindByIdAsync(int id);
    Task<Product> FindByCategoryAsync(string category);
    void Update(Product product);
    void Remove(Product product);
}