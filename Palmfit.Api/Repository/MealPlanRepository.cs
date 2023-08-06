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
		//public Dictionary<MealOfDay, IEnumerable<MealPlanDto>> WeeklyPlan { get; set; }

		public MealPlanRepository(PalmfitDbContext palmfitDbContext)
		{
			_palmfitDbContext = palmfitDbContext;
			
		}


		//public async Task<IEnumerable<MealPlanDto>> WeeklyMealPlan(int week)
		//{
		//	var weekly = new List<MealPlanDto>();

		//	var result = GetDaysRangeForWeek(week);
		//	int[] daysInWeek =  result.ToArray();

		//var breakfast = _palmfitDbContext.Meals.Where(rows => rows.MealOfDay == MealOfDay.Breakfast).Include(prop => prop.Food).GroupBy(row => row.DayOfTheWeek).ToList();
		//var lunch = _palmfitDbContext.Meals.Where(rows => rows.MealOfDay == MealOfDay.Lunch).Include(prop => prop.Food).GroupBy(row => row.DayOfTheWeek).ToList();
		//var dinner = _palmfitDbContext.Meals.Where(rows => rows.MealOfDay == MealOfDay.Dinner).Include(prop => prop.Food).GroupBy(row => row.DayOfTheWeek).ToList();


		//	WeeklyPlan[MealOfDay.Breakfast] = (IEnumerable<MealPlanDto>)breakfast;
		//	WeeklyPlan[MealOfDay.Lunch] = (IEnumerable<MealPlanDto>)lunch;
		//	WeeklyPlan[MealOfDay.Dinner] = (IEnumerable<MealPlanDto>)dinner;

		//	// 0 1 2 3 4 5 6
		//	for(int i = 0; i < result.Length; i++)
		//	{
		//		WeeklyPlan[MealOfDay.Breakfast].ToList().FindIndex(row => row.DayOfTheWeek == Convert.ToString((DayOfWeek)i) &&
		//		WeeklyPlan[MealOfDay.Breakfast].ToList().FindIndex(i) );

					
		//	}



		//}




		//static List<int> GetDaysInWeekForCurrentMonth(int weekNumber)
		//{
		//	// Get the current date
		//	DateTime currentDate = DateTime.Now;

		//	// Get the first day of the current month
		//	DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

		//	// Calculate the start date of the requested week
		//	DateTime startDate = firstDayOfMonth.AddDays((weekNumber - 1) * 7);

		//	// Calculate the end date of the requested week
		//	DateTime endDate = startDate.AddDays(6);

		//	// Create a list to store the days in the week
		//	List<int> daysInWeek = new List<int>();

		//	// Add the days within the week to the list
		//	for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
		//	{
		//		daysInWeek.Add(date.Day);
		//	}

		//	return daysInWeek;
		//}


		//public static int[] GetDaysRangeForWeek(int week)
		//{
		//	if (week < 1)
		//	{
		//		throw new ArgumentException("Week argument must be a positive integer.");
		//	}

		//	int startDay = (week - 1) * 7; // Changed to start from 0
		//	int endDay = week * 7 - 1; // Changed to start from 0 and subtract 1

		//	int[] daysRange = new int[endDay - startDay + 1];
		//	for (int i = 0; i < daysRange.Length; i++)
		//	{
		//		daysRange[i] = startDay + i;
		//	}

		//	return daysRange;
		//}

		public async Task<IEnumerable<MealPlanDto>> GetWeeklyPlan(int week, string appUserId)
		{
			var data = await _palmfitDbContext.Meals.Where(row => row.Week == week).Include(prop => prop.Food).ToListAsync();

			if(!data.Any())
			{
				return null;
			}

			List<MealPlanDto> result = new List<MealPlanDto>();
			foreach (var row in data)
			{
				MealPlanDto weeklyMeals = new MealPlanDto()
				{
					Name = row.Food.Name,
					Description = row.Food.Description,
					Details = row.Food.Details,
					Image = row.Food.Image,
					Calorie = row.Food.Calorie,
					Unit = row.Food.Unit,
					MealOfDay = Convert.ToString((MealOfDay)row.MealOfDay),
					DayOfTheWeek = Convert.ToString((DaysOfWeek)row.DayOfTheWeek),

				};

				result.Add(weeklyMeals);
			}
			return result;
		}


		public async Task<IEnumerable<MealPlanDto>> GetDailyPlan(int day, string appUserId)
		{
			var data = await _palmfitDbContext.Meals.Where(x => (int)x.DayOfTheWeek == day && x.AppUserId == appUserId).Include(prop => prop.Food).ToListAsync();



			if (data.Count() == 0)
				return null;		

			List<MealPlanDto> result = new();
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
					

				};

				result.Add(a);
			}
			
			return result;
		}


		public async Task<string> AddMealPlan(string foodId, string userId,  PostMealDTO mealPlanDTO)
		{

			var result = await _palmfitDbContext.Foods.AnyAsync(row => row.Id == foodId);
			var verify = await _palmfitDbContext.Users.AnyAsync(row => row.Id == userId);
			var checkForDuplicates = await _palmfitDbContext.Meals.AnyAsync(row => row.Week == mealPlanDTO.Week && (int) row.DayOfTheWeek == (int)mealPlanDTO.DayOfTheWeek && (int)row.MealOfDay == (int) mealPlanDTO.MealOfDay && row.FoodId == foodId);


			


			if ((int)mealPlanDTO.MealOfDay < 0 || (int)mealPlanDTO.MealOfDay > 2)
				return "Meal of day is out of range";


			if (mealPlanDTO.Week <= 0 || mealPlanDTO.Week > 53)
			
				return "Week cannot be less than 1 or greater than 53";
			

			if (checkForDuplicates)
			
				return $"database does not accept duplicate, this food has already been assigned to this meal plan!";
			
			if (!result)
				return "No food to add to meal plan";

			if (!verify)
				return "User does not exist!";

				

			Meal meal = new Meal()
			{
				MealOfDay = mealPlanDTO.MealOfDay,
				DayOfTheWeek = mealPlanDTO.DayOfTheWeek,
				Week = mealPlanDTO.Week,
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
