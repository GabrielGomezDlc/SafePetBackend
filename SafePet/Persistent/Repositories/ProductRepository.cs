using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories;

    public class ProductRepository: BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> FindById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        
        public async Task<Product> FindByCategoryAsync(string category)
        {
            return _context.Products.SingleOrDefault(x => x.Category == category);
        }
        
        public async Task<Product> FindByIdAsync(int id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }
    }
    
