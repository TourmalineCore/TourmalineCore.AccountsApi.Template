using Microsoft.AspNetCore.Identity;
using UserManagementService.Core.Interfaces;

namespace UserManagementService.Core.Entities
{
    public class Role : IdentityRole<long>, IIdentityEntity
    {
        private Role() { }

        public Role(string name)
        {
            Name = name;
            NormalizedName = name.Normalize();
        }

        public void Update(string name)
        {
            Name = name;
            NormalizedName = name.Normalize();
        }
    }
}
