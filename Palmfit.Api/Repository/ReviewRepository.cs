using Microsoft.AspNetCore.Mvc;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Repository
{
	public class ReviewRepository
	{
		private readonly PalmfitDbContext _palmfitcontext;

		public ReviewRepository(PalmfitDbContext palmfitcontext)
		{
			_palmfitcontext = palmfitcontext;
		}

		public async Task<string>iew(ReviewDTO reviewDTO, string userId)
		{
			var validateUser = _palmfitcontext.Users.FirstOrDefault(row => row.Id == userId);

			if (validateUser == null)
			{
				
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
		}
	}
}
