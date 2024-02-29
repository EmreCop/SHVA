using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHVA.Data.DatabaseTable
{
  public class Woning
  {
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Adress { get; set; }
    public string? Image { get; set; }

    [ForeignKey("Huisvestingaanbieders")]    
    public virtual int? Huisvestingaanbieder { get; set; }

    [ForeignKey("Rooms")]
    public virtual List<int>? Rooms { get; set; }

    [ForeignKey("Studenten")]
    public virtual List<int>? StudentenIds { get; set; }

  }
}
