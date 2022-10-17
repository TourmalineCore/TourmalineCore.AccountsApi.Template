using System.Collections.Generic;

namespace UserManagementService.Core.Entities;

public enum PrivilegesNames
{
    CanManageEverything = 1,
    CanViewEmployeeList,
    CanViewEmployeePage
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
    public Privilege(long id, PrivilegesNames name)
    {
        Id = id;
        Name = name;
    }
}
