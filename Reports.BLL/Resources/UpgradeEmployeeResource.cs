using System;
using System.ComponentModel.DataAnnotations;

namespace Reports.BLL.Resources
{
    public class UpgradeEmployeeResource
    {
        public Guid? SupervisorId { get; set; } = null;
        public string TypeOfEmployee { get; set; }
    }
}