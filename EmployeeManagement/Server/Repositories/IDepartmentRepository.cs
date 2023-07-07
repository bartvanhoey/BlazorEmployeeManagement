using EmployeeManagement.Shared;

namespace EmployeeManagement.API.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department?> GetDepartment(int departmentId);
    }
}
