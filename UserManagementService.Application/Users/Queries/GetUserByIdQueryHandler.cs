using MediatR;
using UserManagementService.Core.Entities;
using UserManagementService.DataAccess;

namespace UserManagementService.Application.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly ReadDbContext _readDbContext;

        public GetUserByIdQueryHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _readDbContext
                .QueryableAsNoTracking<User>()
                .GetByIdAsync(request.Id);
        }
    }
}
