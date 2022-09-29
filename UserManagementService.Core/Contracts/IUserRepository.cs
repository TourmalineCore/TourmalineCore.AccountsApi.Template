using System.Threading.Tasks;
using UserManagementService.Core.Entities;

namespace UserManagementService.Core.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        public Task AddToRoleAsync(Role role);
    }
}
