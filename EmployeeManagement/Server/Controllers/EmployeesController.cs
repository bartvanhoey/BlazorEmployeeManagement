using EmployeeManagement.API.Repositories;
using EmployeeManagement.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeesController(IEmployeeRepository employeeRepository) => _repo = employeeRepository;


        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedEmployees(int skip = 0, int take = 5)
        {
            try
            {
                return Ok(await _repo.GetEmployees(skip, take));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> GetPagedEmployees()
        {
            try
            {
                return Ok(await _repo.GetEmployees(0, 1000));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var employee = await _repo.GetEmployee(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {

                if (id != employee.EmployeeId)
                {
                    return BadRequest("EmployeeId mismatch");
                }

                var employeeToUpdate = await _repo.GetEmployee(id);


                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id {id} not found");
                }

                return Ok(await _repo.UpdateEmployee(employee));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var dbEmployee = await _repo.GetEmployeeByEmail(employee.Email);
                if (dbEmployee != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await _repo.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee?>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _repo.GetEmployee(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                return await _repo.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }




    }
}
