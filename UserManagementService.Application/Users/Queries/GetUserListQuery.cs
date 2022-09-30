﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Application.Contracts;
using System.Linq;

namespace UserManagementService.Application.Users.Queries
{
    public partial class GetUserListQuery
    {
    }

    public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUserListQuery request)
        {
            var userEntities = await _userRepository.GetAllAsync();

            return userEntities.Select(x => new UserDto(
                x.Id,
                x.Name, 
                x.Surname, 
                x.Email, 
                x.RoleId
                )
            );
        }
    }
}
