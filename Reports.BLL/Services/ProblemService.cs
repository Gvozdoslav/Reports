using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Reports.BLL.Communication;
using Reports.DAL.Entities;
using Reports.DAL.Repository;

namespace Reports.BLL.Services
{
    public class ProblemService : IProblemService
    {
        private IRepository<Problem> _repository;
        private IUnitOfWork _unitOfWork;

        public ProblemService(IRepository<Problem> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Problem> FindById(Guid id)
        {
            return await _repository.FindById(id);
        }

        public async Task<SaveProblemResponse> Delete(Guid id)
        {
            Problem problem = await _repository.FindById(id);

            if (problem is null)
                return new SaveProblemResponse("Problem not found :(");

            try
            {
                _repository.Remove(problem);
                await _unitOfWork.CompleteAsync();

                return new SaveProblemResponse(problem);
            }
            catch (Exception ex)
            {
                return new SaveProblemResponse($"Error during deleting the problem: {ex.Message}");
            }
        }

        public async Task<SaveProblemResponse> Update(Guid id, Problem entity)
        {
            Problem problem = await _repository.FindById(id);

            if (problem is null)
                return new SaveProblemResponse("Problem has not found");

            if (problem.ProblemStatus == ProblemStatus.Resolved)
                return new SaveProblemResponse(problem);

            problem.Touched = false;
            if (!string.IsNullOrWhiteSpace(entity.Description))
            {
                problem.Description += $" Added: {entity.Description}";
                problem.Touched = true;
            }

            problem.ProblemStatus = ProblemStatus.Active;
            if (entity.ProblemStatus > problem.ProblemStatus)
            {
                problem.ProblemStatus = entity.ProblemStatus;
                problem.Touched = true;
            }

            problem.EmployeeId = entity.EmployeeId;
            problem.LastChangingTime = DateTime.Now;

            try
            {
                _repository.Update(problem);
                await _unitOfWork.CompleteAsync();

                return new SaveProblemResponse(problem);
            }
            catch (Exception ex)
            {
                return new SaveProblemResponse($"Error during updating the problem: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Problem>> GetAll()
        {
            return await _repository.GetAll(new QueryParameters());
        }

        public async Task<SaveProblemResponse> SaveAsync(Problem problem)
        {
            problem.CreationTime = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(problem.Description))
                problem.ProblemStatus = ProblemStatus.Active;

            try
            {
                await _repository.AddAsync(problem);
                await _unitOfWork.CompleteAsync();
			         
                return new SaveProblemResponse(problem);
            }
            catch (Exception ex)
            {
                return new SaveProblemResponse($"Error during saving the problem: {ex.Message}");
            }
        }
    }
}