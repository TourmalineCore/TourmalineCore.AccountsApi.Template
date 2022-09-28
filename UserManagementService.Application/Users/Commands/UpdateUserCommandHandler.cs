using MediatR;
using UserManagementService.Core.Entities;
using UserManagementService.DataAccess;

namespace UserManagementService.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly WriteDbContext _writeDbContext;

        public UpdateUserCommandHandler(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _writeDbContext
                .Queryable<User>()
                .GetByIdAsync(request.Id);

            user.Update(request.UserName,
                request.Email,
                request.Name,
                request.Surname,
                request.Patronymic
            );

            await _writeDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
