using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTO
{
    public class EmpDetails
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]

        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        [ForeignKey("department")]
        public string DeptName { get; set; } = string.Empty;

    }
}
