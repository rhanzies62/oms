using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Enums {

    }
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female,
    }
    public enum AccountType
    {
        [Description("Admin")]
        Admin,
        [Description("Employee")]
        Employee,
    }
    public enum Status
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive,
    }
}
