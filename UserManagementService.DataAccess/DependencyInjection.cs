using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagementService.DataAccess
{
    public static class DependencyInjection
    {
            public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                
                services.AddDbContext<UsersDbContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                });

                services.AddScoped<UsersDbContext>();
                return services;
            }
        }
}
