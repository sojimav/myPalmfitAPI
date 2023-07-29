using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.Entities.MealPlan
{
	public class DailyMealPlan : BaseEntity
	{
		public string NameOfDailyMealPlan { get; set; }
		public List<Food> Breakfast { get; set; }
		public List<Food> Launch { get; set; }
		public List<Food> Dinner { get; set; }	
	}
}
