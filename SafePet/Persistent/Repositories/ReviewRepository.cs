using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories;

    public class ReviewRepository: BaseRepository, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task<Review> FindById(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }

        public void Remove(Review review)
        {
            _context.Reviews.Remove(review);
        }
    }
    
