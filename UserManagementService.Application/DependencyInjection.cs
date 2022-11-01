using Microsoft.Extensions.DependencyInjection;
using UserManagementService.Application.Privileges.Commands;
using UserManagementService.Application.Privileges.Queries;
using UserManagementService.Application.Roles.Commands;
using NodaTime;
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
            services.AddTransient<GetUserByIdQueryHandler>();

            services.AddTransient<GetRoleListQueryHandler>();
            services.AddTransient<GetRoleByIdQueryHandler>();
            services.AddTransient<DeleteRoleCommandHandler>();
            services.AddTransient<AddPrivilegeCommandHandler>();

            services.AddTransient<GetPrivilegeListQueryHandler>();
            services.AddTransient<GetPrivilegeByIdQueryHandler>();
            services.AddTransient<DeletePrivilegeCommandHandler>();

            services.AddTransient<IClock, Clock>();


            return services;
        }
    }
}
