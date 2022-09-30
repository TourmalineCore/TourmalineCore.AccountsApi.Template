using UserManagementService.Core.Interfaces;

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

        public string Name { get; set; }
        
        public string NormalizedName { get; set; }

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
