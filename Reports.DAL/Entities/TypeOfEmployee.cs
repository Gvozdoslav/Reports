using System.ComponentModel;

namespace Reports.DAL.Entities
{
    public enum TypeOfEmployee
    {
        [Description("TeamLeader")]
        TeamLeader,
        [Description("Manager")]
        Manager,
        [Description("Slave")]
        Slave,
    }
}