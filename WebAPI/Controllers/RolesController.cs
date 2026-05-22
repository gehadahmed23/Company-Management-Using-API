using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDTO>>> GetRoles()
        {
            var roles = await _roleManager.Roles
                .Select(r => new RoleDTO { Id = r.Id, Name = r.Name ?? string.Empty })
                .ToListAsync();

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            return Ok(new RoleDTO { Id = role.Id, Name = role.Name ?? string.Empty });
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<RoleDTO>> GetRoleByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if (role == null) return NotFound();

            return Ok(new RoleDTO { Id = role.Id, Name = role.Name ?? string.Empty });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleDTO model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return BadRequest(new { message = "Role name is required." });

            if (await _roleManager.RoleExistsAsync(model.Name))
                return BadRequest(new { message = "Role already exists." });

            var role = new IdentityRole(model.Name);
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return CreatedAtAction(nameof(GetRole), new { id = role.Id },
                new RoleDTO { Id = role.Id, Name = role.Name ?? string.Empty });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, RoleDTO model)
        {
            if (id != model.Id) return BadRequest();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(new { message = "Role updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(new { message = "Role deleted successfully." });
        }
    }
}