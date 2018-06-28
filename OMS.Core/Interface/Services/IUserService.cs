using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<User> ListActiveUsers();
        IEnumerable<User> ListInactiveUsers();

        IEnumerable<User> ListUsersByRole(int id);

        Response<User> CreateUser(User User);

        Response<User> UpdateUser(User User);

        Response<User> RemoveUser(int id);

        User GetActiveUser(int id);
        User GetInactiveUser(int id);

    }
}
