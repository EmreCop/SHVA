using Microsoft.EntityFrameworkCore;
using SHVA.Data.DatabaseTable;

namespace SHVA.Data.Services
{
  public class RoomService(IDbContextFactory<ApplicationDbContext> dbContextFactory) : WoningService(dbContextFactory)
  {
    public void AddRoom(Room room)
    {
      using var context = _dbContextFactory.CreateDbContext();
      context.Rooms.Add(room);
      context.SaveChanges();
    }
    public Room GetRoomByID(int id)
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.Rooms.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }
    public Room GetRoomByName(string name)
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.Rooms.SingleOrDefault(x => x.Name == name) ?? throw new InvalidOperationException();
    }

    public void DeleteRoom(int id)
    {
      using var context = _dbContextFactory.CreateDbContext();
      var room = GetRoomByID(id);
      var woning = GetWoningbyID(room.WoningID);
      woning?.Rooms?.Remove(room.Id);
      context.Rooms.Remove(room);
      context.SaveChanges();
    }
    public void UpdateRoom(Room room)
    {
      using var context = _dbContextFactory.CreateDbContext();
      if (!context.Rooms.Contains(room))
      {
        throw new Exception("room does not exits");
      }
      context.Rooms.Update(room);
      context.SaveChanges();
    }

  }
}
