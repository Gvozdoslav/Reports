using System;
using System.Collections.Generic;
using Reports.DAL.Entities;

namespace Reports.BLL.Resources
{
    public class EmployeeResource
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? SupervisorId { get; set; }

        public string TypeOfEmployee { get; set; }

        public IEnumerable<EmployeeResource> Subordinates { get; } = new List<EmployeeResource>();
    }
}