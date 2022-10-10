namespace UserManagementService.Core.Entities;

public enum Privileges
{
    CanManageUsers,
    CanManageRoles,
    CanManageSalary
}

public class Privilege : IIdentityEntity
{
    public long Id { get; private set; }

    public string Name { get; set; }

    public string NormalizedName { get; set; }

    public Role Role { get; private set; }

    public Privilege(string name)
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