using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.BLL.Communication;
using Reports.DAL.Entities;
using Reports.DAL.Repository;

namespace Reports.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IRepository<Employee> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee> FindById(Guid id)
        {
            return await _repository.FindById(id);
        }

        public async Task<SaveEmployeeResponse> Delete(Guid id)
        {
            Employee employee = await _repository.FindById(id);

            if (employee is null)
                return new SaveEmployeeResponse("Employee not found :(");

            try
            {
                _repository.Remove(employee);
                await _unitOfWork.CompleteAsync();

                return new SaveEmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                return new SaveEmployeeResponse("Error during deleting employee");
            }
        }

        public async Task<SaveEmployeeResponse> Update(Guid id, Employee entity)
        {
            Employee employee = await _repository.FindById(id);

            if (employee is null)
                return new SaveEmployeeResponse("Employee not found :(");

            if (entity.SupervisorId is not null)
                employee.SupervisorId = entity.SupervisorId.Value;

            if (employee.TypeOfEmployee is not null)
                employee.TypeOfEmployee = entity.TypeOfEmployee;

            try
            {
                _repository.Update(employee);
                await _unitOfWork.CompleteAsync();

                return new SaveEmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                return new SaveEmployeeResponse("Error during updating employee");
            }
        }

        public async Task<IEnumerable<Employee>> GetAll(QueryParameters queryParameters)
        {
            return await _repository.GetAll(queryParameters);
        }

        public async Task<SaveEmployeeResponse> SaveAsync(Employee employee)
        {

            try
            {
                await _repository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();
			         
                return new SaveEmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                return new SaveEmployeeResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }
    }
}