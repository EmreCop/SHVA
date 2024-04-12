using Microsoft.EntityFrameworkCore;
using SHVA.Data.DatabaseTable;

namespace SHVA.Data.Services
{
  public class StudentService(IDbContextFactory<ApplicationDbContext> dbContextFactory) : RoomService(dbContextFactory)

  {



    public List<Student> GetStudents()
    {
      using var context = _dbContextFactory.CreateDbContext();
      return [.. context.Studenten];
    }

    public Student GetStudentbyID(int id)
    {
      using var context = _dbContextFactory.CreateDbContext();
      return context.Studenten.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public void AddStudent(Student student)
    {
      using var context = _dbContextFactory.CreateDbContext();
      if (!context.Studenten.Contains(student))
      {
        if (student.WoningID != null)
        {
          var woning = GetWoningbyID((int)student.WoningID);
          woning?.StudentenIds?.Add(student.Id);
          if (woning != null)
          {
            UpdateWoning(woning);
          }
        }

        if (student.RoomID != null)
        {
          var room = GetRoomByID((int)student.RoomID);
          room?.StudentenIds?.Add(student.Id);
          if (room != null)
          {
            UpdateRoom(room);
          }
        }


        context.Studenten.Add(student);
        context.SaveChanges();
      }
      else
      {
        throw new Exception("Student alderdy exits");
      }
    }
    public void UpdateStudent(Student student)
    {
      using var context = _dbContextFactory.CreateDbContext();
      context.Studenten.Update(student);
      context.SaveChanges();
    }
    
    public void DeleteStudent(Student student)
    {
      using var context = _dbContextFactory.CreateDbContext();
      if (student.WoningID != null)
      {
        var woning = GetWoningbyID((int)student.WoningID);
        woning?.StudentenIds?.Remove(student.Id);
        if (woning != null)
        {
          UpdateWoning(woning);
        }
      }
      if (student.RoomID != null)
      {
        var room = GetRoomByID((int)student.RoomID);
        room?.StudentenIds?.Remove(student.Id);
        if (room != null)
        {
          UpdateRoom(room);
        }
      }

      context.Studenten.Remove(student);
      context.SaveChanges();
    }


  }
}
