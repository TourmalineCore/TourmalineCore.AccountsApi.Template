using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagementService.Api.Dto.Users;
using UserManagementService.Application.Users.Commands;
using UserManagementService.Application.Users.Queries;

namespace UserManagementService.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly GetUserListQueryHandler _getUserListQueryHandler;
        private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;
        private readonly DeleteUserCommandHandler _deleteUserCommandHandler;

        public UsersController(
            GetUserListQueryHandler getUserListQueryHandler,
            GetUserByIdQueryHandler getUserByIdQueryHandler,
            CreateUserCommandHandler createUserCommandHandler,
            UpdateUserCommandHandler updateUserCommandHandler,
            DeleteUserCommandHandler deleteUserCommandHandler)
        {
            _getUserListQueryHandler = getUserListQueryHandler;
            _getUserByIdQueryHandler = getUserByIdQueryHandler;
            _createUserCommandHandler = createUserCommandHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<UserDto>> FindAll([FromQuery] GetUserListQuery getUserListQuery)
        {
            var users = await _getUserListQueryHandler.Handle(getUserListQuery);

            return users.Select(x => new UserDto(
                x.Id,
                x.Name,
                x.Surname,
                x.Email,
                x.RoleId
              )
          );
        }

        [HttpGet("find")]
        public async Task<UserDto> FindById([FromQuery] GetUserByIdQuery getUserByIdQuery)
        {
            var user = await _getUserByIdQueryHandler.Handle(getUserByIdQuery);

            return new UserDto(
                user.Id,
                user.Name,
                user.Surname,
                user.Email,
                user.RoleId
                );
        }

        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateUserCommand createUserCommand)
        {
            return await _createUserCommandHandler.Handle(createUserCommand);
        }

        [HttpPut("update")]
        public Task Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            return _updateUserCommandHandler.Handle(updateUserCommand);
        }

        [HttpDelete("delete")]
        public Task Delete([FromQuery] DeleteUserCommand deleteUserCommand)
        {
            return _deleteUserCommandHandler.Handle(deleteUserCommand);
        }
    }
}
