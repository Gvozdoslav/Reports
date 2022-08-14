using System.ComponentModel;

namespace Reports.DAL.Entities
{
    public enum ProblemStatus
    {
        [Description("Open")]
        Open,
        [Description("Active")]
        Active,
        [Description("Resolved")]
        Resolved
    }
}