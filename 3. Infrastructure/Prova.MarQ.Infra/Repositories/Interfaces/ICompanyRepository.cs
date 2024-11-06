using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra.Repositories.Interfaces;

public interface ICompanyRepository : IRepository<Company>
{
    Task<Company> GetByIdAsync(Guid id);
    Task<Company> GetByDocumentAsync(string document);
    Task<bool> ExistsByDocumentAsync(string document);
}

