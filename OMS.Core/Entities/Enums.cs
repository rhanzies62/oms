using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female,
    }
    public enum InventoryProcess
    {
        [Description("Incoming")]
        Incoming,
        [Description("OutGoing")]
        OutGoing,
        [Description("Return")]
        Return,
    }


}
