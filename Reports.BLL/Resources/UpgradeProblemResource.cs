using System;
using System.ComponentModel.DataAnnotations;

namespace Reports.BLL.Resources
{
    public class UpgradeProblemResource
    {
        public Guid? EmployeeId { get; set; }
        public string Description { get; set; }
        public string ProblemStatus { get; set; }
    }
}