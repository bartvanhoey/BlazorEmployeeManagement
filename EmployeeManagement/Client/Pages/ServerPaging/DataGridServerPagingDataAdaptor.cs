using EmployeeManagement.Client.Services;
using EmployeeManagement.Shared;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace EmployeeManagement.Client.Pages.ServerPaging;

public class DataGridServerPagingDataAdaptor : DataAdaptor
{
    private readonly IEmployeeService _employeeService;

    public DataGridServerPagingDataAdaptor(IEmployeeService employeeService) => _employeeService = employeeService;

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string additionalParam = null)
    {
        var result = await _employeeService.GetPagedEmployees(dataManagerRequest.Skip, dataManagerRequest.Take);

        var dataResult = new DataResult
        {
            Result = result.Employees,
            Count = result.Count
        };

        return dataResult;
    }
    
}