using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Infra.Repositories.Interfaces;

namespace Prova.MarQ.Infra.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly MarqDbContext _context;

    public EmployeeRepository(MarqDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Employee entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByDocumentAsync(string document)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetByDocumentAsync(string document)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Employee entity)
    {
        throw new NotImplementedException();
    }
}
