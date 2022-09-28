using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserManagementService.Core.Entities;
using UserManagementService.DataAccess;

namespace UserManagementService.Application.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly UsersDbContext _dbContext;

        public GetUserByIdQueryHandler(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _dbContext
                .QueryableAsNoTracking<User>()
                .GetByIdAsync(request.Id);
        }
    }
}
