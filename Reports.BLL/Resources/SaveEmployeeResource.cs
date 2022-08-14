using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;

namespace Reports.BLL.Resources
{
    public class SaveEmployeeResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public Guid? SupervisorId { get; set; }

        [Required]
        public string TypeOfEmployee { get; set; }
    }
}