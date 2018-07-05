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

        Response<Variant> CreateVariant(Variant Variant);

        Response<Variant> UpdateVariant(Variant Variant);

        Response<Variant> RemoveVariant(int VariantID);

        Variant GetVariantByVariantID(int VariantID);

    }
}
