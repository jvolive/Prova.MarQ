using Microsoft.AspNetCore.Mvc;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRecordController : ControllerBase
    {
        private readonly ITimeRecordService _timeRecordService;

        public TimeRecordController(ITimeRecordService timeRecordService)
        {
            _timeRecordService = timeRecordService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeRecord>>> GetAllAsync()
        {
            var timeRecords = await _timeRecordService.GetAllAsync();
            return Ok(timeRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeRecord>> GetByIdAsync(Guid id)
        {
            var timeRecord = await _timeRecordService.GetByIdAsync(id);
            if (timeRecord == null)
                return NotFound();
            return Ok(timeRecord);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(TimeRecord timeRecord)
        {
            await _timeRecordService.AddAsync(timeRecord);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = timeRecord.Id }, timeRecord);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, TimeRecord timeRecord)
        {
            if (id != timeRecord.Id)
                return BadRequest();

            await _timeRecordService.UpdateAsync(timeRecord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _timeRecordService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("delete-by-employee")]
        public async Task<ActionResult> DeleteByEmployeeRegistrationAsync(int employeeRegistration)
        {
            await _timeRecordService.DeleteByEmployeeRegistrationAsync(employeeRegistration);
            return NoContent();
        }

        [HttpGet("range")]
        public async Task<ActionResult<IEnumerable<TimeRecord>>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var timeRecords = await _timeRecordService.GetByDateRangeAsync(startDate, endDate);
            return Ok(timeRecords);
        }

        [HttpGet("employee/{employeeRegistration}/date/{date}")]
        public async Task<ActionResult<TimeRecord>> GetByEmployeeAndDateAsync(int employeeRegistration, DateTime date)
        {
            var timeRecord = await _timeRecordService.GetByEmployeeAndDateAsync(employeeRegistration, date);
            if (timeRecord == null)
                return NotFound();
            return Ok(timeRecord);
        }
    }
}
