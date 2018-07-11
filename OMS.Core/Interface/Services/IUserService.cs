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
        IEnumerable<User> ListUsers(bool isActive);

        Response<User> CreateUser(User user);

        Response<User> UpdateUser(User user);

        Response<User> RemoveUser(int userID);

        User GetUserByID(int userID,bool isActive);
    }
}
