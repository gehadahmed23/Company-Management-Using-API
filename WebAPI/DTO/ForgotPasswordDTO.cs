using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class ForgotPasswordDTO
    {
        [Required, EmailAddress] 
        public string Email { get; set; } = string.Empty;
    }
}
