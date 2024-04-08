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
      using var context = _dbContextFactory.CreateDbContext();
      context.Roles.Add(role);
      context.SaveChanges();
    }

    public IdentityRole GetRollbyID(string id)
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.Roles.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
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
      using var context = _dbContextFactory.CreateDbContext();
      return [.. context.Users];
    }

    public ApplicationUser GetUserByID(string id)
    {
      using var context = _dbContextFactory.CreateDbContext();
      var user = context.Users.SingleOrDefault(x => x.Id == id);
      return user ?? throw new InvalidOperationException();
    }

    public Dictionary<string, string> GetIdentityUserRoles()
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.UserRoles.ToDictionary(ur => ur.UserId, ur => ur.RoleId);
    }


    public void UserRoleManger(IdentityUserRole<string> userRole)
    {
      using var context = _dbContextFactory.CreateDbContext();
      var user = context.UserRoles.FirstOrDefault(x => x.UserId == userRole.UserId);
      if (user != null)
      {
        context.UserRoles.Remove(user);
        context.SaveChanges();
      }
      context.UserRoles.Add(userRole);
      context.SaveChanges();
    }

  }
}
