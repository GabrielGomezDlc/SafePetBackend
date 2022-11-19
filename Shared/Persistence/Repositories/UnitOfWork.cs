
//using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Shared.Domain.Repositories;
//using SafePetBackend.Shared.Persistence.Contexts;


namespace SafePetBackend.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    //private readonly AppDbContext _context;
/*
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
*/
    public async Task CompleteAsync()
    {
        //await _context.SaveChangesAsync();
    }
}
