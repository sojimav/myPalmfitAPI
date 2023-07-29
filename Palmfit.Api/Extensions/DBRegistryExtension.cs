using Microsoft.EntityFrameworkCore;
using Palmfit.Api.Repository;
using Palmfit.Data.AppDbContext;

namespace Palmfit.Api.Extensions
{
    public static class DBRegistryExtension
    {
        public static void AddDbContextAndConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<PalmfitDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Palmfit.Api"));
            });

            services.AddScoped<IMealPlanRepository, MealPlanRepository>();
           
        }
    }
}