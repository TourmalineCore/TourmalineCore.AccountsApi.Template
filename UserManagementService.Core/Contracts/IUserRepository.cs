using System.Threading.Tasks;
using UserManagementService.Core.Entities;

namespace UserManagementService.Core.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        public Task AddRoleAsync(User user, Role role);

        public Task<User> FindByEmailAsync(string email);
    }
}
