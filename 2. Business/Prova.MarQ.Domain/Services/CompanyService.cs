using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Domain.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task AddAsync(Company entity)
    {
        if (await _companyRepository.ExistsByDocumentAsync(entity.Document))
        {
            throw new InvalidOperationException("Empresa com este documento já existe.");
        }

        entity.CreatedAt = DateTimeOffset.UtcNow;
        await _companyRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(Company entity)
    {
        var existingCompany = await _companyRepository.GetByIdAsync(entity.Id);
        if (existingCompany == null)
        {
            throw new KeyNotFoundException("Empresa não encontrada.");
        }

        existingCompany.Name = entity.Name;
        existingCompany.Document = entity.Document;
        existingCompany.UpdatedAt = DateTimeOffset.UtcNow;

        await _companyRepository.UpdateAsync(existingCompany);
    }

    public async Task DeleteAsync(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        if (company == null)
        {
            throw new KeyNotFoundException("Empresa não encontrada.");
        }

        company.IsDeleted = true;
        await _companyRepository.UpdateAsync(company);
    }
}
