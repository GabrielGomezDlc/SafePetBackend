using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories;

    public class ProfileRepository: BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<Profile> FindById(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public void Remove(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }
    }
    
