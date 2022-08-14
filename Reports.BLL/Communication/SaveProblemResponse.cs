using Reports.DAL.Entities;

namespace Reports.BLL.Communication
{
    public class SaveProblemResponse : BaseResponse
    {
        public Problem Problem { get; set; }

        public SaveProblemResponse(bool success, string message, Problem problem)
            : base(success, message)
        {
            Problem = problem;
        }

        public SaveProblemResponse(Problem problem)
            : this(true, string.Empty, problem)
        {
        }

        public SaveProblemResponse(string message)
            : this(false, message, null)
        {
        }
    }
}