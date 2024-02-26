using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHVA.Data.DatabaseTable
{
  public class Student
  {
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }

    [ForeignKey("Woning")]
    public int? WoningID { get; set; }

    [ForeignKey("Room")]
    public int? RoomID { get; set; }
  }
}
