using Prova.MarQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Repositories.Interfaces;

namespace Prova.MarQ.Infra.Repositories;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(MarqDbContext context) : base(context)
    {
    }
}