using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> ListRoles();

        Response<Role> CreateRole(Role Role);

        Response<Role> UpdateRole(Role Role);

        Response<Role> RemoveRole(int roleID);

        Role GetRoleByID(int roleID);

    }
}
