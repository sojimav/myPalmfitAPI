using Microsoft.EntityFrameworkCore;
using Palmfit.Data.Entities.MealPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.AppDbContext
{
	public interface IPalmfitDbContext
	{
		 DbSet<DailyMealPlan> DailyMealPlans { get; set; }
		 DbSet<WeeklyMealPlan> WeeklyMealPlans { get; set; }
	}
}
