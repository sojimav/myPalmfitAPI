using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Microsoft.VisualBasic.FileIO;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
using System.Runtime.InteropServices;
//using Palmfit.Data.Entities.MealPlan;
//using Palmfit.Data.Entities.MealPlan.DTO;

namespace Palmfit.Api.Repository
{
    public partial class MealPlanRepository : IMealPlanRepository
	{
		private readonly PalmfitDbContext _palmfitDbContext;
		private readonly UserManager<AppUser> _userManager;

		public MealPlanRepository(PalmfitDbContext palmfitDbContext, UserManager<AppUser> userManager)
		{
			_palmfitDbContext = palmfitDbContext;
			_userManager = userManager;
		}

		public static int[] GetDaysRangeForWeek(int week)
		{
			if (week < 1)
			{
				throw new ArgumentException("Week argument must be a positive integer.");
			}

			int startDay = (week - 1) * 7 + 1;
			int endDay = week * 7;

			int[] daysRange = new int[endDay - startDay + 1];
			for (int i = 0; i < daysRange.Length; i++)
			{
				daysRange[i] = startDay + i;
			}

			return daysRange;
		}

		public async Task<IEnumerable<MealPlanDto>> Chow(int day, string appUserId)
		{
			var data = await _palmfitDbContext.Meals.Where(x => (int)x.DayOfTheWeek == day && x.AppUserId == appUserId).Include(prop => prop.Food).ToListAsync();



			if (data.Count() == 0)
				return null;

			

			List<MealPlanDto> result = new();

			//Meal mock = MockData();
			//MealPlanDto mealPlan = new MealPlanDto()
			//{
			//	Name = mock.Food.Name,
			//	Description = mock.Food.Description,
			//	Details = mock.Food.Details,
			//	Origin = mock.Food.Origin,
			//	Image = mock.Food.Image,
			//	Calorie = mock.Food.Calorie,
			//	Unit = mock.Food.Unit,
			//	MealOfDay = Convert.ToString(mock.MealOfDay),
			//	DayOfTheWeek = Convert.ToString(mock.DayOfTheWeek)

			//};


			foreach (var item in data)
			{
				MealPlanDto a = new MealPlanDto()
				{
					Name = item.Food.Name,
					Description = item.Food.Description,
					Details = item.Food.Details,
					Origin = item.Food.Origin,
					Image = item.Food.Image,
					Calorie = item.Food.Calorie,
					Unit = item.Food.Unit,
					MealOfDay = Convert.ToString((MealOfDay)item.MealOfDay),
					DayOfTheWeek = Convert.ToString((DaysOfWeek)item.DayOfTheWeek),
					AppUserId = appUserId

				};

				result.Add(a);
			}
			//result.Add(mealPlan);

			return result;
		}


		public async Task<string> AddMealPlan(string foodId, string userId,  PostMealDTO mealPlanDTO)
		{

			var result = await _palmfitDbContext.Foods.AnyAsync(row => row.Id == foodId);
			var verify = await _palmfitDbContext.Users.AnyAsync(row => row.Id == userId);

			if (!result)
				return "No food to add to meal plan";
			if (!verify)
				return "User does not exist!";

			Meal meal = new Meal()
			{
				MealOfDay = mealPlanDTO.MealOfDay,
				DayOfTheWeek = mealPlanDTO.DayOfTheWeek,
				FoodId = foodId,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				IsDeleted = false,
				Id = Guid.NewGuid().ToString(),
				AppUserId = userId
			};

			await _palmfitDbContext.AddAsync<Meal>(meal);
			_palmfitDbContext.SaveChanges();

			return "Food successfully added to Meal Plan!";
		}

		public static Meal MockData()
		{


			Meal meal = new Meal()
			{
				AppUserId = Guid.NewGuid().ToString(),
				FoodId = Guid.NewGuid().ToString(),
				MealOfDay = 0,
				DayOfTheWeek = (DaysOfWeek) 1,
				Food = new Food()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Rice",
					Description = "white",
					Details = "long  thin",
					Origin = "Africa",
					Image = "img/url",
					Calorie = 34,
					Unit = "4",
					FoodClassId = Guid.NewGuid().ToString(),
					FoodClass = new FoodClass()
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Carbohydarate",
						Description = "Energy given",
						Details = "yenyenyen",


					}

				}
			};

			return meal;
		}

	}
}
