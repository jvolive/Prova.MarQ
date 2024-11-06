using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra.Repositories.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetByIdAsync(Guid id);
    Task<Employee> GetByNameAsync(string name);
    Task<Employee> GetByDocumentAsync(string document);
    Task<bool> ExistsByDocumentAsync(string document);
}
