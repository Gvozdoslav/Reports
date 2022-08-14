using Reports.DAL.Database;

namespace Reports.DAL.Repository
{
    public class BaseRepository
    {
        protected readonly ReportsDatabaseContext _context;

        public BaseRepository(ReportsDatabaseContext context)
        {
            _context = context;
        }
    }
}