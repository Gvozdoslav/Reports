using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.BLL.Communication;
using Reports.DAL.Entities;

namespace Reports.BLL.Services
{
    public interface IReportService
    {
        Task<Report> FindById(Guid id);

        Task<SaveReportResponse> Delete(Guid id);

        Task<SaveReportResponse> Update(Guid id, Report entity);
        Task<IEnumerable<Report>> GetAll();
        Task<SaveReportResponse> SaveAsync(Report report);
    }
}