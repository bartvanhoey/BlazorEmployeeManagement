using EmployeeManagement.Client.Services;
using EmployeeManagement.Shared;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public EventCallback OnEmployeeDeleted { get; set; }

        [Inject]
        public IEmployeeService EmployeeService{ get; set; }

        [Parameter]
        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public bool ShowFooter{ get; set; } = true;
        protected bool IsChecked { get; set; }

        [Parameter] public EventCallback<bool> OnEmployeeChecked { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsChecked = (bool)e.Value;
            await OnEmployeeChecked.InvokeAsync(IsChecked);
        }

        protected async Task ClickDelete()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
        }
    }
}
