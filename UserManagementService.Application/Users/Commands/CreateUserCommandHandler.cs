using MediatR;
using UserManagementService.Core.Entities;
using UserManagementService.DataAccess;

namespace UserManagementService.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly ReadDbContext _readDbContext;

        public CreateUserCommandHandler(WriteDbContext writeDbContext, ReadDbContext readDbContext)
        {
            _writeDbContext = writeDbContext;
            _readDbContext = readDbContext;
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

            // Need to save in read base
            //await _readDbContext.AddAsync(user);
            //await _readDbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
