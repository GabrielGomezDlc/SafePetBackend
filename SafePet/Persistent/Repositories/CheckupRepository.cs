using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories; 

public class CheckupRepository: BaseRepository, ICheckupRepository
    {
        public CheckupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Checkup>> ListAsync()
        {
            return await _context.Checkups.ToListAsync();
        }

        public async Task AddAsync(Checkup checkup)
        {
            await _context.Checkups.AddAsync(checkup);
        }

        public async Task<Checkup> FindById(int id)
        {
            return await _context.Checkups.FindAsync(id);
        }

        public void Update(Checkup checkup)
        {
            _context.Checkups.Update(checkup);
        }

        public void Remove(Checkup checkup)
        {
            _context.Checkups.Remove(checkup); //qué hice? xd
            
        }
    }
    
