using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.Entities.MealPlan.DTO
{
	public class WeeklyMealDTO
	{
		public string NameOfWeeklyMealPlan { get; set; }
		public List<DailyMealPlan> weekyPlan { get; set; }
	}
}
