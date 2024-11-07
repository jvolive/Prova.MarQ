using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra.Repositories.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetByNameAsync(string name);
    Task<Employee> GetByDocumentAsync(string document);
    Task<Employee> GetByRegistrationAsync(int registration);
    Task<bool> ExistsByDocumentAsync(string document);
    bool VerifyPin(Employee employee, string pin);
}
