using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserManagementService.Core.Entities;
using UserManagementService.DataAccess;

namespace UserManagementService.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly UsersDbContext _dbContext;

        public CreateUserCommandHandler(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName,
                request.Email,
                request.Password,
                request.Name,
                request.Surname,
                request.Patronymic);

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
