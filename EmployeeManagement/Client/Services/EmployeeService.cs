using EmployeeManagement.Shared;
using System.Net.Http.Json;

namespace EmployeeManagement.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient httpClient) => _http=httpClient;

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var response = await _http.PostAsJsonAsync("api/employees", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task DeleteEmployee(int employeeId) 
            => await _http.DeleteAsync($"api/employees/{employeeId}");

        public async Task<Employee> GetEmployee(int id) 
            => await _http.GetFromJsonAsync<Employee>($"api/employees/{id}");

        public async Task<IEnumerable<Employee>> GetEmployees() 
            => await _http.GetFromJsonAsync<Employee[]>("api/employees");

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await _http.PutAsJsonAsync($"api/employees/{employee.EmployeeId}", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();

        }
    }
}
