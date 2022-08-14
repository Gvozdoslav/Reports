using System;
using System.Collections.Generic;

namespace Reports.DAL.Entities
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public TypeOfEmployee? TypeOfEmployee { get; set; }
        public Guid? SupervisorId { get; set; }
        public Employee Supervisor { get; set; }
        public Report Report { get; set; }
        public IEnumerable<Employee> Subordinates { get; set; } = new List<Employee>();
        public IEnumerable<Problem> Problems { get; set; } = new List<Problem>();
    }
}