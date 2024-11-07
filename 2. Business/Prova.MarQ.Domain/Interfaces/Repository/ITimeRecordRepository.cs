using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Repositories.Interfaces;

public interface ITimeRecordRepository : IRepositoryBase<TimeRecord>
{
    Task DeleteByEmployeeRegistrationAsync(int employeeRegistration);
    Task<IEnumerable<TimeRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<TimeRecord> GetByEmployeeAndDateAsync(int employeeRegistration, DateTime date);
}