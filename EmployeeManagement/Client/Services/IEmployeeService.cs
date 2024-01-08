using EmployeeManagement.Shared;

namespace EmployeeManagement.Client.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDataResult> GetPagedEmployees(int skip, int take);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> CreateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
    }
}
