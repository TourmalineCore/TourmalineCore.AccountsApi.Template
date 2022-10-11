using Microsoft.AspNetCore.Mvc;
using UserManagementService.Application.Users;
using UserManagementService.Application.Users.Commands;
using UserManagementService.Application.Users.Queries;
using UserDto = UserManagementService.Api.Dto.Users.UserDto;

namespace UserManagementService.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly GetUserListQueryHandler _getUserListQueryHandler;
        private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;
        private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
        private readonly AddRoleToUserCommandHandler _addRoleToUserCommandHandler;
        private readonly CreatedUserHandler _createdUserHandler;

        public UsersController(
            GetUserListQueryHandler getUserListQueryHandler,
            GetUserByIdQueryHandler getUserByIdQueryHandler,
            UpdateUserCommandHandler updateUserCommandHandler,
            DeleteUserCommandHandler deleteUserCommandHandler,
            AddRoleToUserCommandHandler addRoleToUserCommandHandler,
            CreatedUserHandler createdUserHandler)
        {
            _getUserListQueryHandler = getUserListQueryHandler;
            _getUserByIdQueryHandler = getUserByIdQueryHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
            _addRoleToUserCommandHandler = addRoleToUserCommandHandler;
            _createdUserHandler = createdUserHandler;
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
            return await _createdUserHandler.HandleNewUser(createUserCommand);
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

        [HttpPost("add-role")]
        public Task AddRole([FromBody] AddRoleToUserCommand addRoleToUserCommand)
        {
            return _addRoleToUserCommandHandler.Handle(addRoleToUserCommand);
        }
    }
}
