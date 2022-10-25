using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Application.Privileges
{
    public class PrivilegeDto
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<string> Roles { get; private set; }

        public PrivilegeDto(
            long id,
            string name)
        {
            Id = id;
            Name = name;
        }
    }
}
