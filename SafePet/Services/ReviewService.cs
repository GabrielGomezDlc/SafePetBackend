using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Domain.Services.Communication;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Security.Persistence.Repositories;


namespace SafePetBackend.SafePet.Services;

public class ReviewService: IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _reviewRepository.ListAsync();
    }

    public async Task<ReviewResponse> SaveAsync(Review review)
    {
        try
        {
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(review);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while saving the review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> UpdateAsync(int id, Review comment)
    {
        var existingReview = await _reviewRepository.FindById(id);

        if (existingReview == null)
            return new ReviewResponse("Comment not found.");

        existingReview.Comment = comment.Comment;

        try
        {
            _reviewRepository.Update(existingReview);
            await _unitOfWork.CompleteAsync();

            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while updating the comment: {e.Message}");
        }
    }

    public async Task<ReviewResponse> DeleteAsync(int id)
    {
        var existingReview = await _reviewRepository.FindById(id);

        if (existingReview == null)
            return new ReviewResponse("Comment not found.");

        try
        {
            _reviewRepository.Remove(existingReview);
            await _unitOfWork.CompleteAsync();

            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ReviewResponse($"An error occurred while deleting the comment: {e.Message}");
        }
    }
    
    public async Task<Review> GetByVeterinarianIdAsync(int id)
    {
        var user = await _reviewRepository.FindByVeterinarianIdAsync(id);
        if (user == null) throw new KeyNotFoundException("Review not found");
        return user;
    }
}