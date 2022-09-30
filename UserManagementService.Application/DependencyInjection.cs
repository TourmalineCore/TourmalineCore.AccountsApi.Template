using Microsoft.Extensions.DependencyInjection;
using UserManagementService.Application.Roles.Commands;
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

            services.AddTransient<CreateRoleCommandHandler>();
            services.AddTransient<UpdateRoleCommandHandler>();
            services.AddTransient<DeleteRoleCommandHandler>();

            services.AddTransient<GetUserByIdQueryHandler>();
            services.AddTransient<GetUserListQueryHandler>();

            services.AddTransient<GetRoleListQueryHandler>();
            services.AddTransient<GetRoleListQueryHandler>();

            return services;
        }
    }
}
