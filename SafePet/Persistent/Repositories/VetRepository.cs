using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories
{
    public class VetRepository: BaseRepository, IVetRepository
    {
        public VetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Vet>> ListAsync()
        {
            return await _context.Vets.ToListAsync();
        }

        public async Task AddAsync(Vet vet)
        {
            await _context.Vets.AddAsync(vet);
        }

        public async Task<Vet> FindById(int id)
        {
            return await _context.Vets.FindAsync(id);
        }
        

        public void Update(Vet vet)
        {
            _context.Vets.Update(vet);
        }

        public void Remove(Vet vet)
        {
            _context.Vets.Remove(vet);
        }
    }
    
}