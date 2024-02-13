using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHVA.Data.DatabaseTable
{
    public class Woning
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Prijs { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Adress { get; set; }

        [ForeignKey("Student")]
        public virtual List<int>? StudentenIds { get; set; }
        public bool Beschikbaar { get; set; }

    }
}
