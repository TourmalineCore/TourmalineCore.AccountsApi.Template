using Microsoft.AspNetCore.Mvc;
using UserManagementService.Api.Dto.Roles;
using UserManagementService.Application.Roles.Queries;

namespace UserManagementService.Api.Controllers
{
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private readonly GetRoleListQueryHandler _getRoleListQueryHandler;

        public RolesController(GetRoleListQueryHandler getRoleListQueryHandler)
        {
            _getRoleListQueryHandler = getRoleListQueryHandler;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<RoleDto>> FindById([FromQuery] GetRoleListQuery getRoleListQuery)
        {
            var roles = await _getRoleListQueryHandler.Handle(getRoleListQuery);

            return roles.Select(x => new RoleDto(x.Id, x.Name));
        }
    }
}
