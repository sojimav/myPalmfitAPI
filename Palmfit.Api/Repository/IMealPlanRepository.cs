using Microsoft.AspNetCore.Mvc;
using Palmfit.Data.Entities;
//using Palmfit.Data.Entities.MealPlans.DTO;

namespace Palmfit.Api.Repository
{
	public interface IMealPlanRepository
	{
		//public IEnumerable<List<MealPlan>> GetDailyOrWeeklyPlan(int week, bool isWeek = true);

		Task<IEnumerable<MealPlanDto>> GetWeeklyPlan(int week, string appUserId);
		 Task<IEnumerable<MealPlanDto>> GetDailyPlan(int day, string appUserId);
		Task<string> AddMealPlan(string foodId, string userId, PostMealDTO mealPlanDTO);
	}
}
