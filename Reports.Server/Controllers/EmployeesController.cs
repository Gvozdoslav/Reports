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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public IActionResult Find(Guid id)
        {
            if (id == Guid.Empty)
                return StatusCode((int) HttpStatusCode.BadRequest);

            Task<Employee> employee = _service.FindById(id);
            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeResource>> GetAllAsync([FromQuery] QueryParameters queryParameters)
        {
            IEnumerable<Employee> employees =  await
                _service.GetAll(queryParameters);
            IEnumerable<EmployeeResource> resources = _mapper
                .Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);
            return resources;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Employee employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            SaveEmployeeResponse result = await _service.SaveAsync(employee);

            if (!result.Success)
                return BadRequest(result.Message);

            EmployeeResource employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Upgrade(Guid id, [FromBody] UpgradeEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Employee employee = _mapper.Map<UpgradeEmployeeResource, Employee>(resource);
            SaveEmployeeResponse result = await _service.Update(id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            EmployeeResource employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            SaveEmployeeResponse result = await _service.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            EmployeeResource resource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(resource);
        }
    }
}