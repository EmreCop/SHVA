using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SHVA.Data.Services
{
  public class RoleService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
  {
    private IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;

    public void AddRoll(IdentityRole role)
    {
      using var contex = _dbContextFactory.CreateDbContext();
      contex.Roles.Add(role);
      contex.SaveChanges();
    }

    public IdentityRole GetRollbyID(string id)
    {
      using var contex = _dbContextFactory.CreateDbContext();
      return contex.Roles.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public List<IdentityRole> GetRoles()
    {
      using var context = _dbContextFactory.CreateDbContext();
      return [.. context.Roles];
    }

    public List<ApplicationUser> GetUsers()
    {
      using var contex = _dbContextFactory.CreateDbContext();
      return [.. contex.Users];
    }

    public ApplicationUser GetUserbyID(string id)
    {
      using var contex = _dbContextFactory.CreateDbContext();
      var user = contex.Users.SingleOrDefault(x => x.Id == id);
      return user ?? throw new InvalidOperationException();
    }

    public Dictionary<string, string> GetIdentityUserRoles()
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.UserRoles.ToDictionary(ur => ur.UserId, ur => ur.RoleId);
    }


    public void GiveUserRoll(IdentityUserRole<string> userrole)
    {
      using var context = _dbContextFactory.CreateDbContext();
      context.UserRoles.Add(userrole);
      context.SaveChanges();
    }

    public void UpdateUserRoll(IdentityUserRole<string> userrole)
    {
      using var context = _dbContextFactory.CreateDbContext();
      context.UserRoles.Update(userrole);
      context.SaveChanges();
    }

  }
}
