using System.Collections.Generic;

namespace UserManagementService.Core.Entities;

public enum PrivilegesNames
{
    CanManageUsers = 1,
    CanManageRoles,
    CanManageSalary
}

public class Privilege : IIdentityEntity
{
    public long Id { get; private set; }

    public PrivilegesNames Name { get; private set; }

    public List<Role> Roles { get; private set; }

    // To Db Context
    private Privilege()
    {
    }
}
