using System;
using System.Threading.Tasks;
using Reports.DAL.Database;

namespace Reports.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ReportsDatabaseContext _context;

        public UnitOfWork(ReportsDatabaseContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose() => _context?.Dispose();
    }
}