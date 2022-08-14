using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Database;
using Reports.DAL.Entities;

namespace Reports.DAL.Repository
{
    public class ProblemRepository : BaseRepository, IRepository<Problem>
    {
        public ProblemRepository(ReportsDatabaseContext context)
            : base(context)
        {
        }

        public async Task AddAsync(Problem entity)
        {
            await _context.Problems.AddAsync(entity);
        }

        public async Task<Problem> FindById(Guid id)
        {
            return await _context.Problems.FindAsync(id);
        }

        public async Task<IEnumerable<Problem>> GetAll(QueryParameters queryParameters)
        {
            return await _context.Problems.ToListAsync();
        }

        public void Remove(Problem entity)
        {
            _context.Problems.Remove(entity);
        }

        public void Update(Problem entity)
        {
            _context.Problems.Update(entity);
        }
    }
}