using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDDemo.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext context;

        public EmployeesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return this.context.Employee;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await this.context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            this.context.Entry(employee).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                this.context.Employee.Add(employee);
                await this.context.SaveChangesAsync();

                return CreatedAtAction("GetEmployees", new { id = employee.ID }, employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await this.context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            this.context.Employee.Remove(employee);
            await this.context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return this.context.Employee.Any(e => e.ID == id);
        }
    }
}

