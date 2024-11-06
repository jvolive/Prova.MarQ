using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra
{
    public class MarqDbContext : DbContext
    {
        public MarqDbContext(DbContextOptions<MarqDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
