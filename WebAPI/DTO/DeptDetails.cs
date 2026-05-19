using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class DeptDetails
    {
        public int Id { get; set; }

        [Required]
        public string DeptName { get; set; }
        public List<string> EmployeeNames { get; set; } = new List<string>();
    }
}
