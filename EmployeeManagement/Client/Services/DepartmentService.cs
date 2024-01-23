using EmployeeManagement.Shared;
using System.Net.Http.Json;


namespace EmployeeManagement.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;

        public DepartmentService(HttpClient httpClient) => _http=httpClient;

        public async Task<Department> GetDepartment(int id)
            => await _http.GetFromJsonAsync<Department>($"api/departments/{id}");

        public async Task<IEnumerable<Department>> GetDepartments()
            => await _http.GetFromJsonAsync<Department[]>("api/departments");

    }
}
