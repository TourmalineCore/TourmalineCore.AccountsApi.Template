using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagementService.Api.Dto.Users;
using UserManagementService.Application.Users.Commands;
using UserManagementService.Application.Users.Queries;

namespace UserManagementService.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("find")]
        public async Task<UserDto> FindById([FromQuery] GetUserByIdQuery getUserByIdQuery)
        {
            var user = await _mediator.Send(getUserByIdQuery);

            return new UserDto(user.UserName, user.Email, user.Name, user.Surname, user.Patronymic);
        }

        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateUserCommand createUserCommand)
        {
            return await _mediator.Send(createUserCommand);
        }

        [HttpPut("update")]
        public Task Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            return _mediator.Send(updateUserCommand);
        }

        [HttpDelete("delete")]
        public Task Delete([FromQuery] DeleteUserCommand deleteUserCommand)
        {
            return _mediator.Send(deleteUserCommand);
        }
    }
}
