using Microsoft.AspNetCore.Mvc;
using UserManagementService.Api.Dto.Roles;
using UserManagementService.Application.Roles.Commands;
using UserManagementService.Application.Roles.Queries;

namespace UserManagementService.Api.Controllers
{
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private readonly GetRoleListQueryHandler _getRoleListQueryHandler;
        private readonly GetRoleByIdQueryHandler _getRoleByIdQueryHandler;

        private readonly CreateRoleCommandHandler _createRoleCommandHandler;
        private readonly UpdateRoleCommandHandler _updateRoleCommandHandler;
        private readonly DeleteRoleCommandHandler _deleteRoleCommandHandler;

        public RolesController(
            CreateRoleCommandHandler createRoleCommandHandler,
            GetRoleListQueryHandler getRoleListQueryHandler,
            GetRoleByIdQueryHandler getRoleByIdQueryHandler,
            UpdateRoleCommandHandler updateRoleCommandHandler,
            DeleteRoleCommandHandler deleteRoleCommandHandler)
        {
            _createRoleCommandHandler = createRoleCommandHandler;
            _getRoleListQueryHandler = getRoleListQueryHandler;
            _getRoleByIdQueryHandler = getRoleByIdQueryHandler;
            _updateRoleCommandHandler = updateRoleCommandHandler;
            _deleteRoleCommandHandler = deleteRoleCommandHandler;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<RoleDto>> FindById([FromQuery] GetRoleListQuery getRoleListQuery)
        {
            var roles = await _getRoleListQueryHandler.Handle(getRoleListQuery);

            return roles.Select(x => new RoleDto(x.Id, x.Name));
        }

        [HttpGet("find")]
        public async Task<RoleDto> FindById([FromQuery] GetRoleByIdQuery getRoleByIdQuery)
        {
            var role = await _getRoleByIdQueryHandler.Handle(getRoleByIdQuery);

            return new RoleDto(role.Id, role.Name);
        }

        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateRoleCommand createRoleCommand)
        {
            return await _createRoleCommandHandler.Handle(createRoleCommand);
        }

        [HttpPut("update")]
        public Task Update([FromBody] UpdateRoleCommand updateRoleCommand)
        {
            return _updateRoleCommandHandler.Handle(updateRoleCommand);
        }

        [HttpDelete("delete")]
        public Task Delete([FromQuery] DeleteRoleCommand deleteRoleCommand)
        {
            return _deleteRoleCommandHandler.Handle(deleteRoleCommand);
        }
    }
}
