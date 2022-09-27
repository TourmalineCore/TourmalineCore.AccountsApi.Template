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

            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            //services.AddDbContext<ReadDbContext>(options =>
            //{
            //    options.UseNpgsql(connectionString);
            //});


            services.AddScoped<WriteDbContext>(provider => provider.GetService<WriteDbContext>());
            //services.AddScoped<ReadDbContext>(provider => provider.GetService<ReadDbContext>());

            return services;
        }
    }
}
