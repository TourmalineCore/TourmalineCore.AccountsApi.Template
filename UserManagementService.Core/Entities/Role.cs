using Microsoft.AspNetCore.Identity;
using UserManagementService.Core.Interfaces;
using System.Collections.Generic;

namespace UserManagementService.Core.Entities
{
    public class Role : IdentityRole<long>, IIdentityEntity
    {
        // For DB Context
        public Role()
        {

        }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
