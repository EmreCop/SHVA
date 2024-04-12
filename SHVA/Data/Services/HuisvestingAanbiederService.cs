using Microsoft.EntityFrameworkCore;
using SHVA.Data.DatabaseTable;

namespace SHVA.Data.Services
{
  public class HuisvestingAanbiederService (IDbContextFactory<ApplicationDbContext> dbContextFactory)
  {
    private IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;

    public void AddHuisvestingAanbieder(HuisVestingAanbieder huisvestingAanbieder)
    {
      using var context = _dbContextFactory.CreateDbContext();
      context.Huisvestingaanbieders.Add(huisvestingAanbieder);
      context.SaveChanges();
    }

    public HuisVestingAanbieder GetHuisvestingAanbiederbyID(int id)
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.Huisvestingaanbieders.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public HuisVestingAanbieder GetHuisvestingAanbiederbyName(string name)
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.Huisvestingaanbieders.SingleOrDefault(x => x.Name == name) ?? throw new InvalidOperationException();
    }


    public List<HuisVestingAanbieder> GetHuisvestingAanbieders()
    {
      using var context = _dbContextFactory.CreateDbContext();
      return [.. context.Huisvestingaanbieders];
    }

    public void DeleteHuisvestingAanbiederbyId(int id)
    {
      var context = _dbContextFactory.CreateDbContext();
      context.Huisvestingaanbieders.Remove(GetHuisvestingAanbiederbyID(id));
      context.SaveChanges();
    }

    public void UpdateHuisvestingAanbieder(HuisVestingAanbieder huisvestingAanbieder)
    {
      using var context = _dbContextFactory.CreateDbContext();
      if (!context.Huisvestingaanbieders.Contains(huisvestingAanbieder))
      {
        throw new Exception("HuisvestingAanbieder Does not Exits");
      }
      context.Huisvestingaanbieders.Update(huisvestingAanbieder);
      context.SaveChanges();
    }
  }
}
