using Microsoft.EntityFrameworkCore;

namespace Oncologia.Persistence
{
    public class OncologiaDbContextFactory : DesignTimeDbContextFactoryBase<OncologiaDbContext>
    {
        protected override OncologiaDbContext CreateNewInstance(DbContextOptions<OncologiaDbContext> options)
        {
            return new OncologiaDbContext(options);
        }
    }
}
