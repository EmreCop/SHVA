using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHVA.Data.DatabaseTable;

namespace SHVA.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Student> Studenten { get; set; }
        public DbSet<Woning> Woningen { get; set; }
        public DbSet<Room> Rooms {  get; set; }

        public DbSet<HuisVestingAanbieder> Huisvestingaanbieders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      var AdminAcc = new ApplicationUser { UserName = "Admin", Email = "Admin@Admin.com",NormalizedUserName ="ADMIN@ADMIN.COM" ,EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEHs8qsBZiHjVXTwnpf7lLaD5a+csu3RzglxieaBDv2UwV5XoZADRAMrfENY6VOXqFQ==", SecurityStamp = "ZKZ4CTLIQRJTWOY6QFECHZLSQUOZNEBQ", ConcurrencyStamp = "06be31d8-2cc6-4fcb-9c11-5619f83402df", LockoutEnabled = false };
      var AdminRole = new IdentityRole { Id = "6fa6823d-3004-47ee-b55b-86554da82ee9" , Name = "Admin" };
      var MedewerkerRole = new IdentityRole { Id = "34fab195-1d73-40bb-bae4-ddd5169ace39", Name = "Medewerker" };
      var AdminUserRole = new IdentityUserRole<string> {UserId = AdminAcc.Id , RoleId = AdminRole.Id };
      
      builder.Entity<ApplicationUser>().HasData(AdminAcc);
      builder.Entity<IdentityRole>().HasData(AdminRole , MedewerkerRole);
      builder.Entity<IdentityUserRole<string>>().HasData(AdminUserRole);
      base.OnModelCreating(builder);
    }
  }
}
