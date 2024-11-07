
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Domain.Services;

public class CompanyService : ServiceBase<Company>, ICompanyService
{
    public CompanyService(IRepositoryBase<Company> repository) : base(repository)
    {
    }
}
