using Microsoft.AspNetCore.Mvc;
using UserManagementService.Application.Users;
using UserManagementService.Application.Users.Commands;
using UserManagementService.Application.Users.Queries;

namespace UserManagementService.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly GetUserListQueryHandler _getUserListQueryHandler;
        private readonly GetUserByEmailQueryHandler _getUserByEmailQueryHandler;
        private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;
        private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
        private readonly AddRoleToUserCommandHandler _addRoleToUserCommandHandler;

        public UsersController(
            GetUserListQueryHandler getUserListQueryHandler,
            GetUserByEmailQueryHandler getUserByEmailQueryHandler,
            CreateUserCommandHandler createUserCommandHandler,
            UpdateUserCommandHandler updateUserCommandHandler,
            DeleteUserCommandHandler deleteUserCommandHandler,
            AddRoleToUserCommandHandler addRoleToUserCommandHandler,
            GetUserByIdQueryHandler getUserByIdQueryHandler)
        {
            _getUserListQueryHandler = getUserListQueryHandler;
            _getUserByEmailQueryHandler = getUserByEmailQueryHandler;
            _createUserCommandHandler = createUserCommandHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
            _addRoleToUserCommandHandler = addRoleToUserCommandHandler;
            _getUserByIdQueryHandler = getUserByIdQueryHandler;
        }

        [HttpGet("all")]
        public Task<IEnumerable<UserDto>> FindAll([FromQuery] GetUserListQuery getUserListQuery)
        {
            return _getUserListQueryHandler.Handle(getUserListQuery);
        }

        [HttpGet("findByEmail/{email}")]
        public Task<UserDto> FindByEmail([FromRoute] GetUserByEmailQuery getUserByEmailQuery)
        {
            return _getUserByEmailQueryHandler.Handle(getUserByEmailQuery);
        }

        [HttpGet("findById/{id}")]
        public Task<UserDto> FindById([FromRoute] GetUserByIdQuery getUserByIdQuery)
        {
            return _getUserByIdQueryHandler.Handle(getUserByIdQuery);
        }

        [HttpPost("create")]
        public Task<long> Create([FromBody] CreateUserCommand createUserCommand)
        {
            return _createUserCommandHandler.Handle(createUserCommand);
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
