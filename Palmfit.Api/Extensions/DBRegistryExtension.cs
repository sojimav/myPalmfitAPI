using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Palmfit.Api.Repository;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Extensions
{
    public static class DBRegistryExtension
    {
        public static void AddDbContextAndConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<PalmfitDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Palmfit.Data"));
            });

            services.AddIdentity<AppUser,IdentityRole>()
                .AddEntityFrameworkStores<PalmfitDbContext>()
                .AddDefaultTokenProviders();  

            services.AddScoped<IMealPlanRepository, MealPlanRepository>();
            services.AddScoped<IRegister, RegisterRepository>();
           
        }
    }
}