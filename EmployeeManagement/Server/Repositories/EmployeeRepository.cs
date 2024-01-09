using EmployeeManagement.Server;
using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace EmployeeManagement.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext appDbContext) => _db = appDbContext;

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee?> DeleteEmployee(int employeeId)
        {
            var dbEmployee = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (dbEmployee != null)
            {
                _db.Employees.Remove(dbEmployee);
                await _db.SaveChangesAsync();
                return dbEmployee;
            }

            return null;
        }

        public async Task<Employee?> GetEmployee(int employeeId)
            => await _db.Employees.Include(e => e.Department).FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        public async Task<Employee?> GetEmployeeByEmail(string email)
            => await _db.Employees.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<EmployeeDataResult> GetEmployees(int skip = 0, int take = 5, string? orderBy = null)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                var result = new EmployeeDataResult
                {
                    Employees = _db.Employees.Skip(skip).Take(take),
                    Count = await _db.Employees.CountAsync()
                };

                return result;
            }
            else
            {
                var result = new EmployeeDataResult
                {
                    Employees = _db.Employees.OrderBy(orderBy).Skip(skip).Take(take),
                    Count = await _db.Employees.CountAsync()
                };

                return result;
            }
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _db.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                                         || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var dbEmployee = _db.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (dbEmployee != null)
            {
                dbEmployee.FirstName = employee.FirstName;
                dbEmployee.LastName = employee.LastName;
                dbEmployee.Email = employee.Email;
                dbEmployee.DateOfBrith = employee.DateOfBrith;
                dbEmployee.Gender = employee.Gender;
                dbEmployee.DepartmentId = employee.DepartmentId;
                dbEmployee.PhotoPath = employee.PhotoPath;

                await _db.SaveChangesAsync();
                return dbEmployee;
            }

            return null;
        }
    }
}