using EmployeeManagement.Shared;
using System.Net.Http.Json;

namespace EmployeeManagement.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient httpClient) => _http=httpClient;

        public async Task<Employee?> CreateEmployee(Employee? employee)
        {
            if (employee == null) return null;
            employee.Department = null;
            var response = await _http.PostAsJsonAsync("api/employees", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task DeleteEmployee(int employeeId) 
            => await _http.DeleteAsync($"api/employees/{employeeId}");

        public async Task<EmployeeDataResult?> GetPagedEmployees(int skip, int take)
        {
            return await _http.GetFromJsonAsync<EmployeeDataResult>($"api/employees/paged?skip={skip}&take={take}");
        }

        public async Task<EmployeeDataResult?> GetCustomSortedEmployees(int skip, int take, string? orderBy = null)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return await _http.GetFromJsonAsync<EmployeeDataResult>($"api/employees/paged?skip={skip}&take={take}");
            return await _http.GetFromJsonAsync<EmployeeDataResult>($"api/employees/custom-sort?skip={skip}&take={take}&orderby={orderBy}");

        }


        public async Task<Employee?> GetEmployee(int id) 
            => await _http.GetFromJsonAsync<Employee>($"api/employees/{id}");

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employeeDataResult = await _http.GetFromJsonAsync<EmployeeDataResult>("api/employees");
            return employeeDataResult.Employees;
        }

        public async Task<Employee?> UpdateEmployee(Employee? employee)
        {
            var response = await _http.PutAsJsonAsync($"api/employees/{employee.EmployeeId}", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();

        }
    }
}
