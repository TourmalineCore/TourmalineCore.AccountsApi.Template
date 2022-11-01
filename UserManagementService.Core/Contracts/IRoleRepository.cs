using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Core.Entities;

namespace UserManagementService.Core.Contracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task UpdateRoleAsync(Role role, List<Privilege> privilege);
    }
}
