using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reports.BLL.Communication;
using Reports.BLL.Extensions;
using Reports.BLL.Resources;
using Reports.BLL.Services;
using Reports.DAL.Entities;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;
        private readonly IMapper _mapper;

        public ReportsController(IReportService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public IActionResult Find(Guid id)
        {
            if (id == Guid.Empty)
                return StatusCode((int) HttpStatusCode.BadRequest);

            Task<Report> report = _service.FindById(id);
            if (report is null)
                return NotFound();

            return Ok(report);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] SaveReportResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Report report = _mapper.Map<SaveReportResource, Report>(resource);
            SaveReportResponse result = await _service.SaveAsync(report);

            if (!result.Success)
                return BadRequest(result.Message);

            ReportResource reportResource = _mapper.Map<Report, ReportResource>(result.Report);
            return Ok(reportResource);
        }

        [HttpGet]
        public async Task<IEnumerable<ReportResource>> GetAll()
        {
            IEnumerable<Report> reports = await
                _service.GetAll();
            IEnumerable<ReportResource> resources =
                _mapper.Map<IEnumerable<Report>, IEnumerable<ReportResource>>(reports);
            return resources;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpgradeReportResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Report report = _mapper.Map<UpgradeReportResource, Report>(resource);
            SaveReportResponse result = await _service.Update(id, report);

            if (!result.Success)
                return BadRequest(result.Message);

            ReportResource reportResource = _mapper.Map<Report, ReportResource>(result.Report);
            return Ok(reportResource);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            SaveReportResponse result = await _service.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            ReportResource reportResource = _mapper.Map<Report, ReportResource>(result.Report);
            return Ok(reportResource);
        }
    }
}