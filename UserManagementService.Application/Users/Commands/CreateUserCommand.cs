
using MediatR;

namespace UserManagementService.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<long>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }
    }
}
