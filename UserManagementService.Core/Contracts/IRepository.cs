using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Core.Entities;

namespace UserManagementService.Core.Contracts
{
    public interface IRepository<TEntity> where TEntity : IIdentityEntity
    {
        public Task<long> CreateAsync(TEntity role);

        public Task<TEntity> FindByIdAsync(long id);

        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task RemoveAsync(TEntity entity);

        public Task UpdateAsync(TEntity entity);
    }
}
