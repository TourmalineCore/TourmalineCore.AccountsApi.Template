using MediatR;
using UserManagementService.Core.Entities;
using UserManagementService.DataAccess;

namespace UserManagementService.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly WriteDbContext _writeDbContext;

        public CreateUserCommandHandler(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName,
                request.Email,
                request.Password,
                request.Name,
                request.Surname,
                request.Patronymic);

            await _writeDbContext.AddAsync(user);
            await _writeDbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
