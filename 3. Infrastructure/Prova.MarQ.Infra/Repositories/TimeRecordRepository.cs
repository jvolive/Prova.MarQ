using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Repositories.Interfaces;

namespace Prova.MarQ.Infra.Repositories;

public class TimeRecordRepository : RepositoryBase<TimeRecord>, ITimeRecordRepository
{
    public TimeRecordRepository(MarqDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TimeRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.TimeRecords
            .Where(tr => tr.Date >= startDate && tr.Date <= endDate && !tr.IsDeleted)
            .ToListAsync();
    }

    public async Task<TimeRecord> GetByEmployeeAndDateAsync(int employeeRegistration, DateTime date)
    {
        return await _context.TimeRecords
            .FirstOrDefaultAsync(tr => tr.EmployeeRegistration == employeeRegistration && tr.Date.Date == date.Date && !tr.IsDeleted);
    }

    public async Task DeleteByEmployeeRegistrationAsync(int employeeRegistration)
    {
        var timeRecords = await _context.TimeRecords
            .Where(tr => tr.EmployeeRegistration == employeeRegistration && !tr.IsDeleted)
            .ToListAsync();

        foreach (var record in timeRecords)
        {
            record.IsDeleted = true;
            _context.TimeRecords.Update(record);
        }

        await _context.SaveChangesAsync();
    }
}