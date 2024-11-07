using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Helpers;

namespace Prova.MarQ.Infra.Helpers;

public class RegistrationHelper : IRegistrationHelper
{
    private readonly MarqDbContext _context;

    public RegistrationHelper(MarqDbContext context)
    {
        _context = context;
    }

    public async Task<int> GenerateRegistrationAsync(Employee employee)
    {
        if (employee.Registration > 0)
        {
            return employee.Registration;
        }

        var lastEmployee = await _context.Employees
            .Where(e => !e.IsDeleted)
            .OrderByDescending(e => e.CreatedAt)
            .FirstOrDefaultAsync();

        return (lastEmployee == null) ? 1 : lastEmployee.Registration + 1;
    }
}
