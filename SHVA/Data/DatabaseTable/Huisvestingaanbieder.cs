using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHVA.Data.DatabaseTable
{
  public class HuisVestingAanbieder
  {

    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    [ForeignKey("Woning")]
    public virtual List<int>? WoningIDs { get; set; }

    [ForeignKey("Student")]
    public virtual List<int>? StudentenIds { get; set; }


  }
}
