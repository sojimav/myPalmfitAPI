using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.Entities.MealPlan
{
	public class WeeklyMealPlan : BaseEntity
	{
		public string NameOfWeeklyMealPlan { get; set; } 
		public List<DailyMealPlan> weekyPlan { get; set; }
	}
}
