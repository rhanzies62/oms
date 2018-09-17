using System.ComponentModel;

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
    public enum VariantType
    {
        [Description("Text")]
        Text,
        [Description("Options")]
        Options
    }


}
