using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class Dept_PostPut
    {
        public int Id { get; set; }

        [Required]
        public string DeptName { get; set; }
        public string? Desc { get; set; }
    }
}
