namespace EmployeeManagement.Shared;

public class EmployeeDataResult
{
    public IEnumerable<Employee> Employees { get; set; }
    public int Count { get; set; }
}