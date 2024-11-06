using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Prova.MarQ.Infra.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly MarqDbContext _context;

    public CompanyRepository(MarqDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Company entity)
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

    public Task<IEnumerable<Company>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Company> GetByDocumentAsync(string document)
    {
        throw new NotImplementedException();
    }

    public Task<Company> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Company entity)
    {
        throw new NotImplementedException();
    }
}