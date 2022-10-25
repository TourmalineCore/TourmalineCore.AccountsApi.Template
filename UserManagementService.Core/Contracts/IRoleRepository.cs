using System.Threading.Tasks;
using UserManagementService.Core.Entities;

namespace UserManagementService.Core.Contracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task AddPrivilegeAsync(Role role, Privilege privilege);
    }
}
