using Microsoft.Extensions.DependencyInjection;
using UserManagementService.Application.Roles.Queries;
using UserManagementService.Application.Users.Commands;
using UserManagementService.Application.Users.Queries;

namespace UserManagementService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<CreateUserCommandHandler>();
            services.AddTransient<UpdateUserCommandHandler>();
            services.AddTransient<DeleteUserCommandHandler>();
            services.AddTransient<AddRoleToUserCommandHandler>();

            services.AddTransient<GetUserByEmailQueryHandler>();
            services.AddTransient<GetUserListQueryHandler>();

            services.AddTransient<GetRoleListQueryHandler>();

            return services;
        }
    }
}
