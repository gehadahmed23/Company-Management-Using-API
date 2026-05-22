using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class CreateUserDTO
    {
        [Required] 
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress] 
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? TempPassword { get; set; }
        public List<string> Roles { get; set; } = new();
    }

}
