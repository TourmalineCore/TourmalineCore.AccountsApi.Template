using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using UserManagementService.Application.Roles.Queries;
using UserManagementService.Application.Users.Commands;
using UserManagementService.Application.Users.Queries;
using UserManagementService.DataAccess.Respositories;

namespace UserManagementService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<CreateUserCommandHandler>();
            services.AddTransient<UpdateUserCommandHandler>();
            services.AddTransient<DeleteUserCommandHandler>();
            services.AddTransient<IClock, InstantTime>();
            services.AddTransient<AddRoleToUserCommandHandler>();

            services.AddTransient<GetUserByEmailQueryHandler>();
            services.AddTransient<GetUserListQueryHandler>();
            services.AddTransient<GetUserByIdQueryHandler>();

            services.AddTransient<GetRoleListQueryHandler>();

            return services;
        }
    }
}
