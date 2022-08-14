using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Database;
using Reports.DAL.Entities;

namespace Reports.DAL.Repository
{
    public class ReportRepository : BaseRepository, IRepository<Report>
    {
        public ReportRepository(ReportsDatabaseContext context)
            : base(context)
        {
        }

        public async Task AddAsync(Report entity)
        {
            foreach (Problem problem in _context.Problems)
            {
                if (problem.EmployeeId != entity.EmployeeId)
                    continue;

                entity.Description += problem.Description;
            }
            await _context.Reports.AddAsync(entity);
        }

        public async Task<Report> FindById(Guid id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAll(QueryParameters queryParameters)
        {
            return await _context.Reports.ToListAsync();
        }

        public void Remove(Report entity)
        {
            _context.Reports.Remove(entity);
        }

        public void Update(Report entity)
        {
            _context.Reports.Update(entity);
        }
    }
}