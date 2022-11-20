using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories;

    public class VeterinarianNearYouRepository: BaseRepository, IVeterinarianNearYouRepository
    {
        public VeterinarianNearYouRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VeterinarianNearYou>> ListAsync()
        {
            return await _context.VeterinariansNearYou.ToListAsync();
        }

        public async Task AddAsync(VeterinarianNearYou veterinarianNearYou)
        {
            await _context.VeterinariansNearYou.AddAsync(veterinarianNearYou);
        }

        public async Task<VeterinarianNearYou> FindById(int id)
        {
            return await _context.VeterinariansNearYou.FindAsync(id);
        }

        public void Update(VeterinarianNearYou veterinarianNearYou)
        {
            _context.VeterinariansNearYou.Update(veterinarianNearYou);
        }

        public void Remove(VeterinarianNearYou veterinarianNearYou)
        {
            _context.VeterinariansNearYou.Remove(veterinarianNearYou);
        }
    }
    
