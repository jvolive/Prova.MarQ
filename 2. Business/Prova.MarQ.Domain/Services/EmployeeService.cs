using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Helpers;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Domain.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPinHelper _pinHelper;

        public EmployeeService(IEmployeeRepository employeeRepository, IPinHelper pinHelper)
            : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _pinHelper = pinHelper;
        }

        public async Task<bool> VerifyEmployeePinAsync(Employee employee, string pin)
        {
            return _pinHelper.VerifyPin(pin, employee.PinHash, employee.PinSalt);
        }
    }
}