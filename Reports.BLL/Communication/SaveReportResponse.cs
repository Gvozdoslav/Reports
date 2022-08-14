using Reports.DAL.Entities;

namespace Reports.BLL.Communication
{
    public class SaveReportResponse : BaseResponse
    {
        public Report Report { get; set; }

        public SaveReportResponse(bool success, string message, Report report)
            : base(success, message)
        {
            Report = report;
        }

        public SaveReportResponse(Report report)
            : this(true, string.Empty, report)
        {
        }

        public SaveReportResponse(string message)
            : this(false, message, null)
        {
        }
    }
}