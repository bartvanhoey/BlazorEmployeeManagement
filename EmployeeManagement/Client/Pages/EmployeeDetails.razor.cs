using EmployeeManagement.Client.Services;
using EmployeeManagement.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Client.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IEmployeeService EmployeeService{ get; set; }

        public Employee? Employee { get; set; } = new Employee();

        public string Coordinates { get; set; } = "";

        public bool ShowFooter { get; set; }

        public string ButtonText { get; set; } = "Hide Footer";
        public string CssClass { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id ?? "1"));
        }

        protected void MouseMove(MouseEventArgs e) {
            Coordinates = $"x: {e.ClientX} - y: {e.ClientY}";
        }

        protected void ToggleHideShowFooter()
        {
          CssClass =  ButtonText == "Hide Footer" ? "d-none" : "";
          ButtonText =  ButtonText == "Hide Footer" ? "Show Footer" : "Hide Footer";
        }
    }
}
