using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagementService.Application.Users.Commands;

namespace UserManagementService.Api.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<long> Get()
        {
            return await Task.FromResult(123);
        }

        [HttpPost("create")]
        public async Task<long> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            return await _mediator.Send(createUserCommand);
        }
    }
}
