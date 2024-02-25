using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SHVA.Data.DatabaseTable;

namespace SHVA.Data.Services
{
  public class WoningService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
  {
    public IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;

    public void AddWoning(Woning woning)
    {
      using var contex = _dbContextFactory.CreateDbContext();
      contex.Woningen.Add(woning);
      contex.SaveChanges();
    }

    public Woning GetWoningbyID(int id)
    {
      using var contex = _dbContextFactory.CreateDbContext();
      return contex.Woningen.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public List<Woning> GetWongingen()
    {
      using var context = _dbContextFactory.CreateDbContext();
      return [.. context.Woningen];
    }

    public void DeleteWoningbyId(int id)
    {
      var context = _dbContextFactory.CreateDbContext();
      context.Woningen.Remove(GetWoningbyID(id));
      context.SaveChanges();
    }

    public void UpdateWoning(Woning woning)
    {
      using var context = _dbContextFactory.CreateDbContext();
      if (!context.Woningen.Contains(woning))
      {
        throw new Exception("woning Does not Exits");
      }


      context.Woningen.Update(woning);
      context.SaveChanges();
    }
  }


}
