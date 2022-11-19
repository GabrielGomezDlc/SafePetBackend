using SafePetBackend.SafePet.Domain.Models;

namespace SafePetBackend.SafePet.Domain.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> ListAsync();
    Task AddAsync(Review review);
    Task<Review> FindById(int id);
    void Update(Review review);
    void Remove(Review review);
}