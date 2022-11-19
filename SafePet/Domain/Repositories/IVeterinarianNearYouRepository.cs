
using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IVeterinarianNearYouRepository
{
    Task<IEnumerable<VeterinarianNearYou>> ListAsync();
    Task AddAsync(VeterinarianNearYou veterinarianNearYou);
    Task<VeterinarianNearYou> FindById(int id);
    void Update(VeterinarianNearYou veterinarianNearYou);
    void Remove(VeterinarianNearYou veterinarianNearYou);
}