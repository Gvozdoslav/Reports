using System;
using System.ComponentModel.DataAnnotations;
using Reports.DAL.Entities;

namespace Reports.BLL.Resources
{
    public class SaveProblemResource
    {
        public Guid? EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}