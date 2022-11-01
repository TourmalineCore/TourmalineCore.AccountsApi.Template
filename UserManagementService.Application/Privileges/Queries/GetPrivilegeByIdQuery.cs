using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Privileges.Queries
{
    public class GetPrivilegeByIdQuery
    {
        public long Id { get; set; }
    }
    public class GetPrivilegeByIdQueryHandler : IQueryHandler<GetPrivilegeByIdQuery, PrivilegeDto>
    {
        private readonly IPrivilegeRepository _privilegeRepository;

        public GetPrivilegeByIdQueryHandler(IPrivilegeRepository privilegeRepository)
        {
            _privilegeRepository = privilegeRepository;
        }

        public async Task<PrivilegeDto> Handle(GetPrivilegeByIdQuery request)
        {
            var privilegeEntity = await _privilegeRepository.FindByIdAsync(request.Id);

            return new PrivilegeDto(privilegeEntity.Id, privilegeEntity.Name.ToString());
        }
    }
}
