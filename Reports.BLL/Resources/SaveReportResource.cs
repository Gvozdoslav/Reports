using System;
using System.ComponentModel.DataAnnotations;

namespace Reports.BLL.Resources
{
    public class SaveReportResource
    {
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}