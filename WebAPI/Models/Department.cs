using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Desc  { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
