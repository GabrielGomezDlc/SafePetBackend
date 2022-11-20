using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories;

    public class MostPurchasedProductRepository: BaseRepository, IMostPurchasedProductRepository
    {
        public MostPurchasedProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MostPurchasedProduct>> ListAsync()
        {
            return await _context.MostPurchasedProducts.ToListAsync();
        }

        public async Task AddAsync(MostPurchasedProduct mostPurchasedProduct)
        {
            await _context.MostPurchasedProducts.AddAsync(mostPurchasedProduct);
        }

        public async Task<MostPurchasedProduct> FindById(int id)
        {
            return await _context.MostPurchasedProducts.FindAsync(id);
        }

        public void Update(MostPurchasedProduct mostPurchasedProduct)
        {
            _context.MostPurchasedProducts.Update(mostPurchasedProduct);
        }

        public void Remove(MostPurchasedProduct mostPurchasedProduct)
        {
            _context.MostPurchasedProducts.Remove(mostPurchasedProduct);
        }
    }
    
