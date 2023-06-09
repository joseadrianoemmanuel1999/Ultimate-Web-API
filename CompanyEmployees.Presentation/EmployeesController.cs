using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service;
using Shared.DataTransferObjects;
using Utimate_Web_API.ActionFilters;


namespace CompanyEmployees.Presentation
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;


        public EmployeesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges:
           false);
            return Ok(employees);
        }
        [HttpGet("{id:guid}")]
        public async Task <IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = await _service.EmployeeService.GetEmployee(companyId, id,
           trackChanges: false);
            return Ok(employee);

        }
        [HttpPost]
        public async  Task <IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");
            var employeeToReturn =
            _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges:
            false);
            return CreatedAtRoute("GetEmployeeForCompany", new
            {
                companyId,
                id =
            employeeToReturn.Id
            },
            employeeToReturn);
        }
        [HttpDelete("{id:guid}")]
        public async Task <IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
         await   _service.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges:
            false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public async Task <IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id,
        [FromBody] EmployeeForUpdateDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForUpdateDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, compTrackChanges: false, empTrackChanges: true);
            return NoContent();
        }
        
    }

}