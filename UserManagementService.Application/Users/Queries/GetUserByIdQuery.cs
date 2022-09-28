using MediatR;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public long Id { get; set; }
    }
}
