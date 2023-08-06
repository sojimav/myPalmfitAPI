namespace Palmfit.Api.Repository
{
	public interface IReviewRepository
	{
		Task<string> AddReview(ReviewDTO reviewDTO, string userId);
	}
}
