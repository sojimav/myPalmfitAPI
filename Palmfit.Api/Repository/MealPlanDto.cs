﻿using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;

namespace Palmfit.Api.Repository
{
	public class MealPlanDto
	{
		public string DayOfTheWeek { get; set; }
		public string MealOfDay { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Details { get; set; }
		public string Origin { get; set; }
		public string Image { get; set; }
		public decimal Calorie { get; set; }
		public string Unit { get; set; }
		

	}
}
