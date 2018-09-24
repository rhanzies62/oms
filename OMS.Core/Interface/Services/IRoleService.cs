using OMS.Core.DTO;
using System.Collections.Generic;

namespace OMS.Core.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<DTO.SelectListDto> ListRoles();

        Response<Role> CreateRole(Role Role);

        Response<Role> UpdateRole(Role Role);

        Response<Role> RemoveRole(int roleID);

        Role GetRoleByID(int roleID);

    }
}
