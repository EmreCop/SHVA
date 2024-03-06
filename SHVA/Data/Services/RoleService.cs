using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace SHVA.Data.Services
{
  public class RoleService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
  {
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
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

    public void DeleteRole(string id)
    {
      using var context = _dbContextFactory.CreateDbContext();
      context.Roles.Remove(GetRollbyID(id));
      context.SaveChanges();
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


    public void UserRoleManger(IdentityUserRole<string> userrole)
    {
      using var context = _dbContextFactory.CreateDbContext();
      var user = context.UserRoles.FirstOrDefault(x => x.UserId == userrole.UserId);
      if (user != null)
      {
        context.UserRoles.Remove(user);
        context.SaveChanges();
      }
      context.UserRoles.Add(userrole);
      context.SaveChanges();
    }

  }
}
