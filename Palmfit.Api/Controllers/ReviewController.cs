using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Api.Repository;

namespace Palmfit.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IReviewRepository _reviewRepository;

		public ReviewController(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		[HttpPost("add-review")]
		public async Task<IActionResult> AddReview([FromBody] ReviewDTO review, string userId)
		{
			if(userId == null)
			{
				return BadRequest("User Id is invalid!");
			}
			var result = await _reviewRepository.AddReview(review, userId);
			
			if(result == null)
			{
				return NotFound("User does not exist in the database");
			}
			
			return Ok(ModelState);
		}
	}
}
