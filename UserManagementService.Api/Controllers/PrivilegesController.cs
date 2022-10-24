using Microsoft.AspNetCore.Mvc;
using UserManagementService.Application.Privileges;
using UserManagementService.Application.Privileges.Commands;
using UserManagementService.Application.Privileges.Queries;
using UserManagementService.Application.Users.Commands;
using UserManagementService.Application.Users.Queries;

namespace UserManagementService.Api.Controllers
{
    [Route("api/privileges")]
    public class PrivilegesController : Controller
    {
        private readonly GetPrivilegeListQueryHandler _getPrivilegeListQueryHandler;
        private readonly GetPrivilegeByIdQueryHandler _getPrivilegeByIdQueryHandler;
        private readonly DeletePrivilegeCommandHandler _deletePrivilegeCommandHandler;
        private readonly AddRoleToPrivilegeCommandHandler _addRoleToPrivilegeCommandHandler;

        public PrivilegesController(
            GetPrivilegeListQueryHandler getPrivilegeListQueryHandler,
            DeletePrivilegeCommandHandler deletePrivilegeCommandHandler,
            AddRoleToPrivilegeCommandHandler addRoleToPrivilegeCommandHandler,
            GetPrivilegeByIdQueryHandler getPrivilegeByIdQueryHandler)
        {
            _getPrivilegeListQueryHandler = getPrivilegeListQueryHandler;
            _deletePrivilegeCommandHandler = deletePrivilegeCommandHandler;
            _addRoleToPrivilegeCommandHandler = addRoleToPrivilegeCommandHandler;
            _getPrivilegeByIdQueryHandler = getPrivilegeByIdQueryHandler;
        }

        [HttpGet("all")]
        public Task<IEnumerable<PrivilegeDto>> FindAll([FromQuery] GetPrivilegeListQuery getPrivilegeListQuery)
        {
            return _getPrivilegeListQueryHandler.Handle(getPrivilegeListQuery);
        }

        [HttpGet("find/{Id}")]
        public Task<PrivilegeDto> FindByEmail([FromRoute] GetPrivilegeByIdQuery getPrivilegeByIdQuery)
        {
            return _getPrivilegeByIdQueryHandler.Handle(getPrivilegeByIdQuery);
        }

        [HttpDelete("delete")]
        public Task Delete([FromQuery] DeletePrivilegeCommand deletePrivilegeCommand)
        {
            return _deletePrivilegeCommandHandler.Handle(deletePrivilegeCommand);
        }
    }
}
