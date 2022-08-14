using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Database;
using Reports.DAL.Entities;

namespace Reports.DAL.Repository
{
    public class EmployeeRepository : BaseRepository, IRepository<Employee>
    {
        public EmployeeRepository(ReportsDatabaseContext context)
            : base(context)
        {
        }

        public async Task AddAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
        }

        public async Task<Employee> FindById(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll(QueryParameters queryParameters)
        {
            return await _context.Employees
                .Where(e => queryParameters.Name == string.Empty ||
                            e.Name == queryParameters.Name)
                .OrderBy(e => e.Id)
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToListAsync();
        }

        public void Remove(Employee entity)
        {
            foreach (Employee employee in _context.Employees)
            {
                if (employee.Id == entity.SupervisorId)
                    continue;

                employee.SupervisorId = entity.SupervisorId;
                Update(employee);
            }

            _context.Employees.Remove(entity);
        }

        public void Update(Employee entity)
        {
            _context.Employees.Update(entity);
        }
    }
}