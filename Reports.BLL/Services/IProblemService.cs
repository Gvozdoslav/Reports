using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.BLL.Communication;
using Reports.BLL.Resources;
using Reports.DAL.Entities;

namespace Reports.BLL.Services
{
    public interface IProblemService
    {
        Task<Problem> FindById(Guid id);

        Task<SaveProblemResponse> Delete(Guid id);

        Task<SaveProblemResponse> Update(Guid id, Problem entity);
        Task<IEnumerable<Problem>> GetAll();
        Task<SaveProblemResponse> SaveAsync(Problem problem);
    }
}