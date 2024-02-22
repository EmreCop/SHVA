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

        [ForeignKey("Room")]
        public virtual List<int>? Rooms { get; set; }

        [ForeignKey("Student")]
        public virtual List<int>? StudentenIds { get; set; }
      
    }
}
