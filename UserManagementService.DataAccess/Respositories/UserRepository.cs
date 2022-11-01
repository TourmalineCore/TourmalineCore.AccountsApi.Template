using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _usersDbContext;

        public UserRepository(UsersDbContext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }

        public Task AddRoleAsync(User user, Role role)
        {
            user.AddRole(role);
            
            return _usersDbContext.SaveChangesAsync();
        }

        public async Task<long> CreateAsync(User user)
        {
            await _usersDbContext.AddAsync(user);
            await _usersDbContext.SaveChangesAsync();

            return user.Id;
        }

        public Task<User?> FindByEmailAsync(string email)
        {
            return _usersDbContext
                    .Queryable<User>()
                    .Include(x => x.Role)
                    .ThenInclude(x => x.Privileges)
                    .SingleOrDefaultAsync(x => x.Email == email && x.DeletedAtUtc == null);
        }

        public Task<User> FindByIdAsync(long id)
        {
            return _usersDbContext
                    .Queryable<User>()
                    .Include(x => x.Role)
                    .ThenInclude(x => x.Privileges)
                    .SingleAsync(x => x.Id == id && x.DeletedAtUtc == null);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usersDbContext
                .QueryableAsNoTracking<User>()
                .Where(x => x.DeletedAtUtc == null)
                .ToListAsync();
        }

        public Task RemoveAsync(User user)
        {
            _usersDbContext.Remove(user);

            return _usersDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(User user)
        {
            _usersDbContext.Update(user);

            return _usersDbContext.SaveChangesAsync();
        }
    }
}
