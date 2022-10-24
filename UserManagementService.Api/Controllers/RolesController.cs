using Microsoft.AspNetCore.Mvc;
using UserManagementService.Application.Roles;
using UserManagementService.Application.Roles.Commands;
using UserManagementService.Application.Roles.Queries;
using UserManagementService.Application.Users.Commands;

namespace UserManagementService.Api.Controllers
{
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private readonly GetRoleListQueryHandler _getRoleListQueryHandler;
        private readonly GetRoleByIdQueryHandler _getRoleByIdQueryHandler;
        private readonly DeleteRoleCommandHandler _deleteRoleCommandHandler;

        public RolesController (
            GetRoleListQueryHandler getRoleListQueryHandler, 
            GetRoleByIdQueryHandler getRoleByIdQueryHandler,
            DeleteRoleCommandHandler deleteRoleCommandHandler)
        {
            _getRoleListQueryHandler = getRoleListQueryHandler;
            _getRoleByIdQueryHandler = getRoleByIdQueryHandler;
            _deleteRoleCommandHandler = deleteRoleCommandHandler;
        }

        [HttpGet("all")]
        public Task<IEnumerable<RoleDto>> FindById([FromQuery] GetRoleListQuery getRoleListQuery)
        {
            return _getRoleListQueryHandler.Handle(getRoleListQuery);
        }

        [HttpGet("find/{id}")]
        public Task<RoleDto> FindById([FromRoute] GetRoleByIdQuery getRoleByIdQuery)
        {
            return _getRoleByIdQueryHandler.Handle(getRoleByIdQuery);
        }

        [HttpGet("delete")]
        public Task FindById([FromQuery] DeleteRoleCommand deleteRoleCommand)
        {
            return _deleteRoleCommandHandler.Handle(deleteRoleCommand);
        }
    }
}
