using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly WebAPIdbContext _context;

        public DepartmentsController(WebAPIdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeptDetails>>> GetDepartments()
        {
            var deptartments = await _context.Departments.Include(d => d.Employees).ToListAsync();
            var deptDetailsDTO = new List<DeptDetails>();
            foreach (var dept in deptartments)
            {
                var details = new DeptDetails
                {
                    Id = dept.Id,
                    Name = dept.Name,
                    Code = dept.Code,
                    DateOfCreation = dept.DateOfCreation,
                    EmployeeNames = dept.Employees.Select(e => e.Name).ToList()
                };
                deptDetailsDTO.Add(details);
            }
            return deptDetailsDTO;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DeptDetails>> GetDepartment(int id)
        {
            var department = await _context.Departments.Include(e => e.Employees).FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            var deptDetailsDTO = new DeptDetails();

            deptDetailsDTO.Id = department.Id;
            deptDetailsDTO.Name = department.Name;
            deptDetailsDTO.Code = department.Code;
            deptDetailsDTO.DateOfCreation = department.DateOfCreation;
            foreach (var emp in department.Employees) { 
                deptDetailsDTO.EmployeeNames.Add(emp.Name);
            }
           

            return deptDetailsDTO;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Employee>> GetDepartmentByName(string name)
        {
            var departments = await _context.Departments.Where(D => D.Name.ToLower().Contains(name.ToLower())).Include(d => d.Employees).ToListAsync();
            if (departments == null || departments.Count == 0)
            {
                return NotFound();
            }
            var deptDTO = new List<DeptDetails>();
            foreach (var dept in departments)
            {
                var details = new DeptDetails
                {
                    Id = dept.Id,
                    Name = dept.Name,
                    Code = dept.Code,
                    DateOfCreation = dept.DateOfCreation,
                    EmployeeNames = dept.Employees.Select(e => e.Name).ToList()
                };
                deptDTO.Add(details);
            }
            return Ok(deptDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Dept_PostPut department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }


            var deptPut = new Dept_PostPut()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                DateOfCreation = department.DateOfCreation
            };

            try
            {
                existingDepartment.Name = department.Name;
                existingDepartment.Code = department.Code;
                existingDepartment.DateOfCreation = department.DateOfCreation;
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            return Ok(deptPut);
        }



        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Dept_PostPut department)
        {
            var dept = new Department
            {
                Name = department.Name,
                Code = department.Code,
                DateOfCreation = department.DateOfCreation
            };
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = dept.Id }, dept);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

      
    }
}
