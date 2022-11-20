using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace SafePetBackend.SafePet.Persistent.Repositories;

    public class ClientRepository: BaseRepository, IClientRepository
    {
        public  ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _context. Clients.ToListAsync();
        }

        public async Task AddAsync( Client  client)
        {
            await _context. Clients.AddAsync( client);
        }

        public async Task<Client> FindById(int id)
        {
            return await _context. Clients.FindAsync(id);
        }

        public void Update( Client client)
        {
            _context. Clients.Update(client);
        }

        public void Remove( Client  client)
        {
            _context. Clients.Remove(client);
        }
    }
    
