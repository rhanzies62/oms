using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IVariant
    {
        IEnumerable<Variant> ListVariants();

        Response<Variant> CreateVariants(User User);

        Response<Variant> UpdateVariants(User User);

        Response<Variant> RemoveVariants(int id);

        User GetVariant(int id);

    }
}
