using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IVariantService
    {
        IEnumerable<Variant> ListVariants();

        Response<Variant> CreateVariants(Variant Variant);

        Response<Variant> UpdateVariants(Variant Variant);

        Response<Variant> RemoveVariants(int id);

        Variant GetVariant(int id);

    }
}
