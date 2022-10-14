using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Queries
{
    public partial class GetUserByEmailQuery
    {
        public string Email { get; set; }
    }

    public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request)
        {
            var userEntity = await _userRepository.FindByEmailAsync(request.Email);
            var userPrivileges = userEntity.Role.Privileges.Select(x => x.Name).Select(n => n.ToString());

            return new UserDto(userEntity.Id, userEntity.Name, userEntity.Surname, userEntity.Email, userEntity.Role.Name.ToString(), userPrivileges);
        }
    }
}
