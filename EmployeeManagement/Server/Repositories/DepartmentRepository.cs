using EmployeeManagement.Server;
using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _db;

        public DepartmentRepository(AppDbContext appDbContext) => _db = appDbContext;

        public async Task<Department?> GetDepartment(int departmentId) => await _db.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);

        public async Task<IEnumerable<Department>> GetDepartments() => await _db.Departments.ToListAsync();
    }
}
