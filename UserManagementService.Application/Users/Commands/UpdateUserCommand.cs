using MediatR;

namespace UserManagementService.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }
    }
}
