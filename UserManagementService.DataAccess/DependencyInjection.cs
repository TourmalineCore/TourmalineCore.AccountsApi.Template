using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using UserManagementService.Core.Contracts;
using UserManagementService.DataAccess.Respositories;

namespace UserManagementService.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UsersDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                                o => o.UseNodaTime());
            });

            services.AddScoped<UsersDbContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPrivilegeRepository, PrivilegeRepository>();

            return services;
        }
    }
}
