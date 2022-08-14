using System;

namespace Reports.BLL.Resources
{
    public class ProblemResource
    {
        public Guid Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangingTime { get; set; }
        public bool Touched { get; set; }
        public string ProblemStatus { get; set; }
    }
}