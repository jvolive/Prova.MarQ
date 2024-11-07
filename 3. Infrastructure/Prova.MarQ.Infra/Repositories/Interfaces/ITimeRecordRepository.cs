using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra.Repositories.Interfaces
{
    public interface ITimeRecordRepository
    {
        Task AddAsync(TimeRecord timeRecord);
        Task UpdateAsync(TimeRecord timeRecord);
        Task DeleteAsync(Guid id);
        Task DeleteByEmployeeIdAsync(Guid employeeId);
        Task<TimeRecord> GetByIdAsync(Guid id);
        Task<IEnumerable<TimeRecord>> GetByEmployeeIdAsync(Guid employeeId);
        Task<IEnumerable<TimeRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<TimeRecord> GetByEmployeeAndDateAsync(Guid employeeId, DateTime date);
    }
}