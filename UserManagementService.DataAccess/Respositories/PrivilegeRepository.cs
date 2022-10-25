using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess.Respositories
{
    public class PrivilegeRepository : IPrivilegeRepository
    {
        private readonly UsersDbContext _usersDbContext;

        public PrivilegeRepository(UsersDbContext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }

        public async Task<long> CreateAsync(Privilege privilege)
        {
            await _usersDbContext.AddAsync(privilege);
            await _usersDbContext.SaveChangesAsync();

            return privilege.Id;
        }

        public Task<Privilege> FindByIdAsync(long id)
        {
            return _usersDbContext
                   .Queryable<Privilege>()
                   .GetByIdAsync(id);
        }

        public async Task<IEnumerable<Privilege>> GetAllAsync()
        {
            return await _usersDbContext
                .QueryableAsNoTracking<Privilege>()
                .ToListAsync();
        }

        public Task RemoveAsync(Privilege privilege)
        {
            _usersDbContext.Remove(privilege);

            return _usersDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Privilege privilege)
        {
            _usersDbContext.Update(privilege);

            return _usersDbContext.SaveChangesAsync();
        }
    }
}
