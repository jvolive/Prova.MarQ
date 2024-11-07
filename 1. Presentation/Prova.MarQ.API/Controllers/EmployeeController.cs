using Microsoft.AspNetCore.Mvc;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetByIdAsync(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Employee employee)
        {
            await _employeeService.AddAsync(employee);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            await _employeeService.UpdateAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("verify-pin")]
        public async Task<ActionResult<bool>> VerifyPinAsync(Employee employee, string pin)
        {
            var result = await _employeeService.VerifyEmployeePinAsync(employee, pin);
            return Ok(result);
        }
    }
}
