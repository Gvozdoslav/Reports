using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.BLL.Communication;
using Reports.DAL.Entities;

namespace Reports.BLL.Services
{
    public interface IEmployeeService
    {
        Task<Employee> FindById(Guid id);

        Task<SaveEmployeeResponse> Delete(Guid id);

        Task<SaveEmployeeResponse> Update(Guid id, Employee entity);
        Task<IEnumerable<Employee>> GetAll(QueryParameters queryParameters);
        Task<SaveEmployeeResponse> SaveAsync(Employee employee);
    }
}