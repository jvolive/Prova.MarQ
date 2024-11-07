using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Services.Interfaces;

public interface IEmployeeService : IService<Employee>
{
    Task<bool> VerifyEmployeePinAsync(Employee employee, string pin);
}
