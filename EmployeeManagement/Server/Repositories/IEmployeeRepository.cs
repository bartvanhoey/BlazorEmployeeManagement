﻿using EmployeeManagement.Shared;

namespace EmployeeManagement.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDataResult> GetEmployees(int skip, int take, string? orderBy = null);
        Task<Employee?> GetEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(Employee employee);
        Task<Employee?> DeleteEmployee(int employeeId);
        Task<Employee?> GetEmployeeByEmail(string email);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
    }
}
