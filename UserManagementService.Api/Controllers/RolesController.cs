using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Api.Dto.Roles;
using UserManagementService.Application.Roles.Commands;
using UserManagementService.Application.Roles.Queries;

namespace UserManagementService.Api.Controllers
{
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<RoleDto>> FindById([FromQuery] GetRoleListQuery getRoleListQuery)
        {
            var roles = await _mediator.Send(getRoleListQuery);
            return roles.Select(x => new RoleDto(
                x.Id, 
                x.Name, 
                x.NormalizedName
                )
            );
        }

        [HttpGet("find")]
        public async Task<RoleDto> FindById([FromQuery] GetRoleByIdQuery getRoleByIdQuery)
        {
            var role = await _mediator.Send(getRoleByIdQuery);

            return new RoleDto(role.Id, role.Name, role.NormalizedName);
        }

        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateRoleCommand createRoleCommand)
        {
            return await _mediator.Send(createRoleCommand);
        }

        [HttpPut("update")]
        public Task Update([FromBody] UpdateRoleCommand updateRoleCommand)
        {
            return _mediator.Send(updateRoleCommand);
        }

        [HttpDelete("delete")]
        public Task Delete([FromQuery] DeleteRoleCommand deleteRoleCommand)
        {
            return _mediator.Send(deleteRoleCommand);
        }
    }
}
