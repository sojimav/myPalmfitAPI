using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities.MealPlan;
using Palmfit.Data.Entities.MealPlan.DTO;

namespace Palmfit.Api.Repository
{
	public class MealPlanRepository : IMealPlanRepository
	{
		private readonly PalmfitDbContext _palmfitDbContext;

		public MealPlanRepository(PalmfitDbContext palmfitDbContext)
		{
			_palmfitDbContext = palmfitDbContext;
		}


		public DailyMealDTO GetAllDailyMeals()
		{
		   var result = _palmfitDbContext.DailyMealPlans.Where(row => row.Id != null).ToList();
			var AllDailyMealPlan = new DailyMealDTO();
			if (result.Any())
			{
				foreach (var row in result)
				{
					AllDailyMealPlan.NameOfDailyMealPlan = row.NameOfDailyMealPlan;
					AllDailyMealPlan.Breakfast = row.Breakfast;
					AllDailyMealPlan.Launch = row.Launch;
					AllDailyMealPlan.Dinner = row.Dinner;

				}
			}
			else
			{
				
				throw new ArgumentNullException(nameof(result));
			}

			return AllDailyMealPlan;
		}
	}
}
