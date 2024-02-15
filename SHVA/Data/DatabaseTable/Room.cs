using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHVA.Data.DatabaseTable
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [ForeignKey("Woning")]
        public required int WoningID { get; set; }

        [ForeignKey("Student")]
        public virtual List<int>? StudentenIds { get; set; }
 
    }
}
