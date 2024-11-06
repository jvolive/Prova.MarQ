using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Prova.MarQ.Infra
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MarqDbContext>
    {
        public MarqDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MarqDbContext>();

        
            optionsBuilder.UseSqlite("Data Source=Marq.sqlite"); 

            return new MarqDbContext(optionsBuilder.Options);
        }
    }
}
