using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Application.Roles;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Privileges.Queries
{
    public class GetPrivilegeListQuery
    {
    }

    public class GetPrivilegeListQueryHandler : IQueryHandler<GetPrivilegeListQuery, IEnumerable<PrivilegeDto>>
    {
        private readonly IPrivilegeRepository _privilegeRepository;

        public GetPrivilegeListQueryHandler(IPrivilegeRepository privilegeRepository)
        {
            _privilegeRepository = privilegeRepository;
        }

        public async Task<IEnumerable<PrivilegeDto>> Handle(GetPrivilegeListQuery request)
        {
            var privilegeEntities = await _privilegeRepository.GetAllAsync();

            return privilegeEntities.Select(x => new PrivilegeDto(x.Id, x.Name.ToString()));
        }
        
    }
}
