using EmployeeManagement.Shared;

namespace EmployeeManagement.Client.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();

        
        Task<Department> GetDepartment(int id);

    }
}
