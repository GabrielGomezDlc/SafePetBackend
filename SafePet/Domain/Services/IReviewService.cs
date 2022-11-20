using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services.Communication;


namespace SafePetBackend.SafePet.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> ListAsync();
        Task<ReviewResponse> SaveAsync(Review category);
        Task<ReviewResponse> UpdateAsync(int id, Review category);
        Task<ReviewResponse> DeleteAsync(int id);
    }
    
}

