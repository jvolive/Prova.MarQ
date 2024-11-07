using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Infra.Repositories.Interfaces;

namespace Prova.MarQ.Infra.Repositories;

public class TimeRecordRepository : ITimeRecordRepository
{
    private readonly MarqDbContext _context;

    public TimeRecordRepository(MarqDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TimeRecord timeRecord)
    {
        await _context.TimeRecords.AddAsync(timeRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TimeRecord timeRecord)
    {
        _context.TimeRecords.Update(timeRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var timeRecord = await _context.TimeRecords
            .FirstOrDefaultAsync(tr => tr.Id == id);

        if (timeRecord != null)
        {
            timeRecord.IsDeleted = true;
            _context.TimeRecords.Update(timeRecord);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteByEmployeeIdAsync(Guid employeeId)
    {
        var timeRecords = await _context.TimeRecords
            .Where(tr => tr.EmployeeId == employeeId && !tr.IsDeleted)
            .ToListAsync();

        foreach (var timeRecord in timeRecords)
        {
            timeRecord.IsDeleted = true;
            _context.TimeRecords.Update(timeRecord);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<TimeRecord> GetByIdAsync(Guid id)
    {
        return await _context.TimeRecords
            .FirstOrDefaultAsync(tr => tr.Id == id && !tr.IsDeleted);
    }

    public async Task<IEnumerable<TimeRecord>> GetByEmployeeIdAsync(Guid employeeId)
    {
        return await _context.TimeRecords
            .Where(tr => tr.EmployeeId == employeeId && !tr.IsDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<TimeRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.TimeRecords
            .Where(tr => tr.Date >= startDate && tr.Date <= endDate && !tr.IsDeleted)
            .ToListAsync();
    }

    public async Task<TimeRecord> GetByEmployeeAndDateAsync(Guid employeeId, DateTime date)
    {
        return await _context.TimeRecords
            .FirstOrDefaultAsync(tr => tr.EmployeeId == employeeId && tr.Date.Date == date.Date && !tr.IsDeleted);
    }
}
