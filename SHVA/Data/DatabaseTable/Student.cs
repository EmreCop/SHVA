using System.ComponentModel.DataAnnotations;

namespace SHVA.Data.DatabaseTable
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }

    }
}
