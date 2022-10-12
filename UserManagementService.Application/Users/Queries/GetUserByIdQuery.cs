using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Queries
{
    public class GetUserByIdQuery
    {
        public long Id { get; set; }
    }
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request)
        {
            var userEntity = await _userRepository.FindByIdAsync(request.Id);
            var userPrivileges = userEntity.Role.RolePriveleges.Select(x => x.Privilege.Name).Select(n => n.ToString());

            return new UserDto(
                userEntity.Id,
                userEntity.Name,
                userEntity.Surname,
                userEntity.Email,
                userEntity.Role.Name,
                userPrivileges
                );
        }
    }
}
