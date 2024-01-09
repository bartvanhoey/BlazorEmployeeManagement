using EmployeeManagement.Client.Services;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace EmployeeManagement.Client.Pages.CustomDataSorting;

public class CustomDataSortingDataAdaptor : DataAdaptor
{
    private readonly IEmployeeService _employeeService;

    public CustomDataSortingDataAdaptor(IEmployeeService employeeService) => _employeeService = employeeService;

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string additionalParam = null)
    {
        string? orderByString = null;
        if (dataManagerRequest.Sorted != null)
        {
            var sortList = dataManagerRequest.Sorted;
            sortList.Reverse();
            orderByString = string.Join(",", sortList.Select(s => $"{s.Name} {s.Direction}"));
        }
        var result = await _employeeService.GetCustomSortedEmployees(dataManagerRequest.Skip, dataManagerRequest.Take, orderByString);

        var dataResult = new DataResult
        {
            Result = result.Employees,
            Count = result.Count
        };

        return dataResult;
    }
    
}