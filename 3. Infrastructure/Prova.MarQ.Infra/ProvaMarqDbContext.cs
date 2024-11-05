using Microsoft.EntityFrameworkCore;

namespace Prova.MarQ.Infra
{
    public class ProvaMarqDbContext : DbContext
    {
        public ProvaMarqDbContext(DbContextOptions<ProvaMarqDbContext> options)
            : base(options)
        {
            
        }
    }
}
