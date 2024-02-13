using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHVA.Data.DatabaseTable;

namespace SHVA.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Student> Studenten { get; set; }
        public DbSet<Woning> Woningen { get; set; }
    }
}
