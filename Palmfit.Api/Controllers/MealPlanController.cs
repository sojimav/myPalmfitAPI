using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Api.Repository;
using Palmfit.Data.Entities;
using System.Net.WebSockets;
//using Palmfit.Data.Entities.MealPlans.DTO;

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


		[HttpGet("{day:int}", Name = "get/mealplan")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
	    [ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetMealPlan(int day, string appUserId)
		{
			if(day < 0 && day > 6 || appUserId == null)
				return BadRequest("Bad request");

		  	var result  = await _mealPlanRepository.GetDailyPlan(day, appUserId);

			if (result == null)
			{
				return NotFound(result);
			}
			return Ok(result);
		}

		[HttpGet("weekly-plan")]
		public async Task<IActionResult> GetWeeklyPlan(int week, string appUserId)
		{
			if(week < 0 || week > 53|| appUserId == null)
			{
				return BadRequest();
			}

			var result = await _mealPlanRepository.GetWeeklyPlan(week, appUserId);
			if(result == null)
			{
				return NotFound(result);
			}

			return Ok(result);
		}

		[HttpPost("post/mealplan")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode:StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> PostMealPlan([FromBody] PostMealDTO postMealDTO, string userId, string foodId)
		{

			if (postMealDTO == null || foodId == null)
			{
				return BadRequest("Parameter cannot be null!");
			}
			var result = await _mealPlanRepository.AddMealPlan(foodId, userId, postMealDTO);

			if(result == "not found" || result == "User does not exist!")
				return NotFound();

			return Ok(result);	

		}
	}
}
