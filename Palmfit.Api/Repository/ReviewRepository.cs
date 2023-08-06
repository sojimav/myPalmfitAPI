using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Repository
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly PalmfitDbContext _palmfitcontext;

		public ReviewRepository(PalmfitDbContext palmfitcontext)
		{
			_palmfitcontext = palmfitcontext;
		}

		public async Task<string>AddReview(ReviewDTO reviewDTO, string userId)
		{
			var validateUser = await  _palmfitcontext.Users.FirstOrDefaultAsync(row => row.Id == userId);

			if (validateUser == null)
			{
				return "User does not exist!";
			}

			
			Review review = new Review()
			{
				Date = DateTime.Now.Date,
				Comment = reviewDTO.Comment,
				Rating = reviewDTO.Rating,
				Verdict = reviewDTO.Verdict,
				AppUserId = userId,
				Id = Guid.NewGuid().ToString(),
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				IsDeleted = false

			};

			_palmfitcontext.Reviews.Add(review);
			_palmfitcontext.SaveChanges();

			return "Review Updated Sucessfully!";
		}


	}
}
