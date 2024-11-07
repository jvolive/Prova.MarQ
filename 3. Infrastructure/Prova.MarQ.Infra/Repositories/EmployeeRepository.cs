using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Interfaces.Helpers;

namespace Prova.MarQ.Infra.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly MarqDbContext _context;
        private readonly IPinHelper _pinHelper;

        public EmployeeRepository(MarqDbContext context, IPinHelper pinHelper)
            : base(context)
        {
            _context = context;
            _pinHelper = pinHelper;
        }

        public async Task<Employee> GetByRegistrationAsync(int registration)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Registration == registration);
        }

        public bool VerifyPin(Employee employee, string pin)
        {
            return _pinHelper.VerifyPin(pin, employee.PinHash, employee.PinSalt);
        }
    }
}