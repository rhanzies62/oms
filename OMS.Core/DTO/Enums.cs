using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public enum Status
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive,
    }
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female,
    }
}
