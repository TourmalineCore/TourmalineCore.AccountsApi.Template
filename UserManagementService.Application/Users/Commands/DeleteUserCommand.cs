using MediatR;
using UserManagementService.Core.Entities;
using UserManagementService.DataAccess;

namespace UserManagementService.Application.Users.Commands
{
    public partial class DeleteUserCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly WriteDbContext _writeDbContext;

            public DeleteUserCommandHandler(WriteDbContext writeDbContext)
            {
                _writeDbContext = writeDbContext;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _writeDbContext
                .Queryable<User>()
                .GetByIdAsync(request.Id);

                _writeDbContext.Remove(user);

                await _writeDbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
