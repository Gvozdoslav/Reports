using System;

namespace Reports.BLL.Resources
{
    public class UpgradeReportResource
    {
        public Guid? EmployeeId { get; set; }
        public Guid? ProblemId { get; set; }
        public string Description { get; set; }
    }
}