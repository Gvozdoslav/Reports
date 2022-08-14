using System;
using System.ComponentModel.DataAnnotations;

namespace Reports.BLL.Resources
{
    public class ReportResource
    {
        public Guid Id { get; set; }
        public DateTime DateOfReport { get; set; }
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }
    }
}