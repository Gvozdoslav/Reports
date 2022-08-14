using System;
using System.Collections.Generic;

namespace Reports.DAL.Entities
{
    public class Problem
    {
        public Problem()
        {
        }

        public Problem(Guid id, string description, ProblemStatus problemStatus = ProblemStatus.Open)
        {
            Id = id;
            Description = description;
            ProblemStatus = problemStatus;
        }

        public DateTime CreationTime { get; set; }
        public DateTime LastChangingTime { get; set; }
        public bool Touched { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProblemStatus ProblemStatus { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}