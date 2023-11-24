using Microsoft.EntityFrameworkCore;
using WheaterForeCast.DB;

namespace WheaterForeCast.Services
{
    public static class DepencyInjection
    {
        public static IServiceCollection Services(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Db"));
            });
            services.AddScoped<AppDbContext>();
            services.AddScoped<UserServices>();
            return services;
        }
    }
}
