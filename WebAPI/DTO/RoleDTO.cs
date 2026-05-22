using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class RoleDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required] 
        public string Name { get; set; } = string.Empty;
    }
}
