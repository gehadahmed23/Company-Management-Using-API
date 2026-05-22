using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class Dept_PostPut
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You Should Enter Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "You Should Enter Code")]
        public string Code { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
