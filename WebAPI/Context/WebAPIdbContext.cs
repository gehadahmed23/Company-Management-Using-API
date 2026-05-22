using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAPI.Context
{
    public class WebAPIdbContext : IdentityDbContext<ApplicationUser>
    {
        public WebAPIdbContext(DbContextOptions<WebAPIdbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
