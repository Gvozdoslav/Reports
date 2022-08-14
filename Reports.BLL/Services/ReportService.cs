using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.BLL.Communication;
using Reports.DAL.Entities;
using Reports.DAL.Repository;

namespace Reports.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IRepository<Report> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Report> FindById(Guid id)
        {
            return await _repository.FindById(id);
        }

        public async Task<SaveReportResponse> Delete(Guid id)
        {
            Report report = await _repository.FindById(id);

            if (report is null)
                return new SaveReportResponse("Report not found :(");

            try
            {
                _repository.Remove(report);
                await _unitOfWork.CompleteAsync();

                return new SaveReportResponse(report);
            }
            catch (Exception ex)
            {
                return new SaveReportResponse($"Error during deleting the report: {ex.Message}");
            }
        }

        public async Task<SaveReportResponse> Update(Guid id, Report entity)
        {
            Report report = await _repository.FindById(id);

            if (report is null)
                return new SaveReportResponse("Report has not found");

            report.DateOfReport = DateTime.Now;
            report.Description = entity.Description;
            report.EmployeeId = entity.EmployeeId;

            try
            {
                _repository.Update(report);
                await _unitOfWork.CompleteAsync();

                return new SaveReportResponse(report);
            }
            catch (Exception ex)
            {
                return new SaveReportResponse($"Error during updating the report: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Report>> GetAll()
        {
            return await _repository.GetAll(new QueryParameters());
        }

        public async Task<SaveReportResponse> SaveAsync(Report report)
        {
            report.DateOfReport = DateTime.Now;

            try
            {
                await _repository.AddAsync(report);
                await _unitOfWork.CompleteAsync();
			         
                return new SaveReportResponse(report);
            }
            catch (Exception ex)
            {
                return new SaveReportResponse($"Error during saving the report: {ex.Message}");
            }
        }
    }
}