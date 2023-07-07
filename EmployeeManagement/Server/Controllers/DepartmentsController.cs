using EmployeeManagement.API.Repositories;
using EmployeeManagement.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentsController(IDepartmentRepository departmentRepository)
            => _repo = departmentRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetEmployees()
        {
            try
            {
                return Ok(await _repo.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                var dbDepartment = await _repo.GetDepartment(id);
                if (dbDepartment == null)
                {
                    return NotFound();
                }

                return Ok(dbDepartment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
    }
