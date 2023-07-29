using Palmfit.Data.Entities.MealPlan.DTO;

namespace Palmfit.Api.Repository
{
	public interface IMealPlanRepository
	{
		DailyMealDTO GetAllDailyMeals();
	}
}
