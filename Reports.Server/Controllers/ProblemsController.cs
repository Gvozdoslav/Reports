using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProblemsController : ControllerBase
    {
        private IProblemService _service;
        private IMapper _mapper;

        public ProblemsController(IProblemService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public IActionResult FindById(Guid id)
        {
            if (id == Guid.Empty)
                return StatusCode((int) HttpStatusCode.BadRequest);

            Task<Problem> problem = _service.FindById(id);
            if (problem is null)
                return NotFound();

            return Ok(problem);
        }

        [HttpGet("creationTime/{dateTime:datetime}")]
        public async Task<IEnumerable<ProblemResource>> FindByCreationTime(DateTime dateTime)
        {
            return await Task.FromResult(GetAll()
                .Result.Where(pr => pr.CreationTime == dateTime));
        } 

        [HttpGet("lastChangingDateTime/{dateTime:datetime}")]
        public async Task<IEnumerable<ProblemResource>> FindByLastChangingTime(DateTime dateTime)
        {
            return await Task.FromResult(GetAll()
                .Result.Where(pr => pr.CreationTime == dateTime));
        }

        [HttpGet("employee/{id:guid}")]
        public async Task<IEnumerable<ProblemResource>> FindProblemsByEmployee(Guid id)
        {
            return
                await Task
                    .FromResult(GetAll()
                        .Result.Where(pr => pr.EmployeeId == id));
        }

        [HttpGet("employeeTouched/{id:guid}")]
        public async Task<IEnumerable<ProblemResource>> FindProblemsByEmployeeTouchedProblem(Guid id)
        {
            return
                await Task
                    .FromResult(GetAll()
                        .Result.Where(pr =>
                            pr.EmployeeId == id &&
                            pr.Touched));
        }

        [HttpGet]
        public async Task<IEnumerable<ProblemResource>> GetAll()
        {
            IEnumerable<Problem> problems =  await
                _service.GetAll();
            IEnumerable<ProblemResource> resources = _mapper
                .Map<IEnumerable<Problem>, IEnumerable<ProblemResource>>(problems);
            return resources;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] SaveProblemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Problem problem = _mapper.Map<SaveProblemResource, Problem>(resource);
            SaveProblemResponse result = await _service.SaveAsync(problem);

            if (!result.Success)
                return BadRequest(result.Message);

            ProblemResource problemResource = _mapper.Map<Problem, ProblemResource>(result.Problem);
            return Ok(problemResource);
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpgradeProblemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Problem problem = _mapper.Map<UpgradeProblemResource, Problem>(resource);
            SaveProblemResponse result = await _service.Update(id, problem);

            if (!result.Success)
                return BadRequest(result.Message);

            ProblemResource problemResource = _mapper.Map<Problem, ProblemResource>(result.Problem);
            return Ok(problemResource);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            SaveProblemResponse result = await _service.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            ProblemResource resource = _mapper.Map<Problem, ProblemResource>(result.Problem);
            return Ok(resource);
        }
    }
}