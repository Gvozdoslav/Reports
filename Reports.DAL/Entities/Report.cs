using System;
using System.Collections.Generic;

namespace Reports.DAL.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime DateOfReport { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee{ get; set; }
        public IEnumerable<Problem> Problems { get; set; } = new List<Problem>();

    }
}