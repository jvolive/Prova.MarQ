using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Domain.Services
{
    public class TimeRecordService : ServiceBase<TimeRecord>, ITimeRecordService
    {
        private readonly ITimeRecordRepository _timeRecordRepository;

        public TimeRecordService(ITimeRecordRepository timeRecordRepository) : base(timeRecordRepository)
        {
            _timeRecordRepository = timeRecordRepository;
        }

        public async Task DeleteByEmployeeRegistrationAsync(int employeeRegistration)
        {
            await _timeRecordRepository.DeleteByEmployeeRegistrationAsync(employeeRegistration);
        }

        public async Task<IEnumerable<TimeRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _timeRecordRepository.GetByDateRangeAsync(startDate, endDate);
        }

        public async Task<TimeRecord> GetByEmployeeAndDateAsync(int employeeRegistration, DateTime date)
        {
            return await _timeRecordRepository.GetByEmployeeAndDateAsync(employeeRegistration, date);
        }
    }
}
