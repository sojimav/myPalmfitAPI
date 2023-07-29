using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Api.Repository;

namespace Palmfit.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MealPlanController : ControllerBase
	{
		private readonly IMealPlanRepository _mealPlanRepository;

		public MealPlanController(IMealPlanRepository mealPlanRepository)
		{
			_mealPlanRepository = mealPlanRepository;
		}

		[HttpGet("daily-meal-plan")]
		[ProducesResponseType(statusCode: 200)]
		public IActionResult GetDailyAllMealPlan()
		{
			var result = _mealPlanRepository.GetAllDailyMeals();

			return Ok(result);
		}
	}
}
