using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.DTO;

namespace WebAPI.Context
{
    public class WebAPIdbContext : DbContext
    {
        public WebAPIdbContext(DbContextOptions<WebAPIdbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WebAPI.DTO.DeptDetails> DeptEmpDetails { get; set; } = default!;
    }
}
