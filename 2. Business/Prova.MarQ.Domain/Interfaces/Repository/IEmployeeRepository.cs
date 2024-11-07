using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Repositories.Interfaces;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<Employee> GetByRegistrationAsync(int registration);
    bool VerifyPin(Employee employee, string pin);
}
