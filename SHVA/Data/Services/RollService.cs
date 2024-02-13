using Microsoft.EntityFrameworkCore;

namespace SHVA.Data.Services
{
    public class RollService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;

      
    }
}
