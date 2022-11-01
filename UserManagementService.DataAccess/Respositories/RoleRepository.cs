using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess.Respositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UsersDbContext _usersDbContext;

        public RoleRepository(UsersDbContext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }

        public async Task<long> CreateAsync(Role role)
        {
            await _usersDbContext.AddAsync(role);
            await _usersDbContext.SaveChangesAsync();

            return role.Id;
        }
        public async Task UpdateRoleAsync(Role role, List<Privilege> privileges)
        {
            role.UpdateRole(privileges);
            await _usersDbContext.SaveChangesAsync();
        }

        public Task<Role> FindByIdAsync(long id)
        {
            return _usersDbContext
                    .Queryable<Role>()
                    .GetByIdAsync(id);
        }

        public Task<Role> FindOneAsync(long id)
        {
            return _usersDbContext
                    .Queryable<Role>()
                    .GetByIdAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _usersDbContext
                .QueryableAsNoTracking<Role>()
                .ToListAsync();
        }

        public Task RemoveAsync(Role role)
        {
            _usersDbContext.Remove(role);

            return _usersDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Role role)
        {
            _usersDbContext.Update(role);

            return _usersDbContext.SaveChangesAsync();
        }
    }
}
