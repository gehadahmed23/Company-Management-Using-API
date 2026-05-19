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
    public class EmployeesController : ControllerBase
    {
        private readonly WebAPIdbContext _context;

        public EmployeesController(WebAPIdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpDetails>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(e => e.department).ToListAsync();
            var empDTO = new List<EmpDetails>();
            foreach (var emp in employees)
            {
                var details = new EmpDetails
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    IsActive = emp.IsActive,
                    DeptName = emp.department.Name,
                    HireDate = emp.HireDate,
                    Salary = emp.Salary,
                    Email = emp.Email,
                    PhoneNumber = emp.PhoneNumber,

                };
                empDTO.Add(details);
            }
            return empDTO;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var emp = await _context.Employees.Include(d => d.department).FirstOrDefaultAsync(e=> e.Id ==id);

            if (emp == null)
            {
                return NotFound();
            }
            var empDTO = new EmpDetails
            {
                Id = emp.Id,
                Name = emp.Name,
                IsActive = emp.IsActive,
                DeptName = emp.department.Name,
                HireDate = emp.HireDate,
                Salary = emp.Salary,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
            };
            return Ok(empDTO);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Employee>> GetEmployeeByName(string name)
        {
            var employees = await _context.Employees.Where(E => E.Name.ToLower().Contains(name.ToLower())).Include(d => d.department).ToListAsync();
            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }
            var empDTO = new List<EmpDetails>();
            foreach (var emp in employees)
            {
                var details = new EmpDetails
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    IsActive = emp.IsActive,
                    DeptName = emp.department.Name,
                    HireDate = emp.HireDate,
                    Salary = emp.Salary,
                    Email = emp.Email,
                    PhoneNumber = emp.PhoneNumber,

                };
                empDTO.Add(details);
            }
            return Ok(empDTO);
        }

        [HttpGet]
        [Route("Email/{email}")]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var employeeDb = await _context.Employees.FindAsync(id);
            if (employeeDb == null) { 
                return NotFound();
            }
            var empDto = new Emp_PutPost
            {
                Id = employeeDb.Id,
                Name = employeeDb.Name,
                IsActive = employeeDb.IsActive,
                DepartmentId = employeeDb.DeptId,
                HireDate = employeeDb.HireDate,
                Salary = employeeDb.Salary,
                Email = employeeDb.Email,
                PhoneNumber = employeeDb.PhoneNumber,
            };
            try
            {
                employeeDb.Name = employee.Name;
                employeeDb.Salary = employee.Salary;
                employeeDb.Address = employee.Address;
                employeeDb.Email = employee.Email;
                employeeDb.PhoneNumber = employee.PhoneNumber;
                employeeDb.Age = employee.Age;
                employeeDb.IsActive = employee.IsActive;
                employeeDb.HireDate = employee.HireDate;
                employeeDb.ImageName = employee.ImageName;

                _context.Employees.Update(employeeDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
               Console.WriteLine(err.ToString());
            }

            return Ok(empDto);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Emp_PutPost empDTO)
        {
            var employee = new Employee
            {
                Id = empDTO.Id,
                Name = empDTO.Name,
                IsActive = empDTO.IsActive,
                DeptId = empDTO.DepartmentId,
                HireDate = empDTO.HireDate,
                Salary = empDTO.Salary,
                Email = empDTO.Email,
                PhoneNumber = empDTO.PhoneNumber,

            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted Successfully" });
        }

    }
}
