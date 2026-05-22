using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class UpdateUserDTO
    {
        [Required] 
        public string Id { get; set; } = string.Empty;
        [Required] 
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress] 
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
