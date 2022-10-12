using System.Collections.Generic;

namespace UserManagementService.Core.Entities
{
    public enum Roles
    {
        Admin,
        Employee,
        Seo
    }

    public class Role : IIdentityEntity
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string NormalizedName { get; private set; }

        public List<Privilege> Privileges { get; private set; }

        // For Db Context
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
