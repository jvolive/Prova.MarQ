using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra.Repositories.Interfaces
{
    public interface ITimeRecordRepository : IRepository<TimeRecord>
    {
        Task DeleteByEmployeeRegistrationAsync(int employeeRegistration);
        Task<IEnumerable<TimeRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<TimeRecord> GetByEmployeeAndDateAsync(int employeeRegistration, DateTime date);
    }
}