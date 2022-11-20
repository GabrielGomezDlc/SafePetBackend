using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while saving the product: {e.Message}");
        }
    }

    public async Task<Product> GetByCategoryAsync(string category)
    {
        var user = await _productRepository.FindByCategoryAsync(category);
        if (user == null) throw new KeyNotFoundException("Product not found");
        return user;
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        var user = await _productRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("Product not found");
        return user;
    }
    
    public async Task<ProductResponse> UpdateAsync(int id, Product title)
    {
        var existingProduct = await _productRepository.FindById(id);

        if (existingProduct == null)
            return new ProductResponse("Category not found.");

        existingProduct.Title = title.Title;

        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while updating the title: {e.Message}");
        }
    }

    public async Task<ProductResponse> DeleteAsync(int id)
    {
        var existingProduct = await _productRepository.FindById(id);

        if (existingProduct == null)
            return new ProductResponse("Title not found.");

        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ProductResponse($"An error occurred while deleting the title: {e.Message}");
        }
    }
}