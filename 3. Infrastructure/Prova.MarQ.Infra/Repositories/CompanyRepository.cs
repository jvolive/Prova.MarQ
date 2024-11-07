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

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        return await _context.Companies
            .Include(c => c.Employees)
            .Where(c => !c.IsDeleted)
            .ToListAsync();
    }

    public async Task AddAsync(Company entity)
    {
        if (await ExistsByDocumentAsync(entity.Document))
        {
            throw new InvalidOperationException("A empresa com este documento já existe.");
        }
        entity.CreatedAt = DateTimeOffset.UtcNow;
        await _context.Companies.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Company entity)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == entity.Id && !c.IsDeleted);

        if (company == null)
        {
            throw new KeyNotFoundException("Empresa não encontrada.");
        }

        company.Name = entity.Name;
        company.Document = entity.Document;
        company.UpdatedAt = DateTimeOffset.UtcNow;
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var company = await _context.Companies
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

        if (company == null)
        {
            throw new KeyNotFoundException("Empresa não encontrada.");
        }

        company.IsDeleted = true;
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }

    public async Task<Company> GetByNameAsync(string name)
    {
        return await _context.Companies
            .Include(c => c.Employees)
            .FirstOrDefaultAsync(e => e.Name == name && !e.IsDeleted);
    }

    public async Task<Company> GetByDocumentAsync(string document)
    {
        return await _context.Companies
            .Include(c => c.Employees)
            .FirstOrDefaultAsync(c => c.Document == document && !c.IsDeleted);
    }

    public async Task<bool> ExistsByDocumentAsync(string document)
    {
        return await _context.Companies.AnyAsync(c => c.Document == document && !c.IsDeleted);
    }
}