using Reports.DAL.Entities;

namespace Reports.BLL.Communication
{
    public class SaveEmployeeResponse : BaseResponse
    {
        public Employee Employee { get; set; }

        private SaveEmployeeResponse(bool success, string message, Employee employee)
            : base(success, message)
        {
            Employee = employee;
        }

        public SaveEmployeeResponse(Employee employee)
            : this(true, string.Empty, employee)
        {
        }

        public SaveEmployeeResponse(string message)
            : this(false, message, null)
        {
        }
    }
}