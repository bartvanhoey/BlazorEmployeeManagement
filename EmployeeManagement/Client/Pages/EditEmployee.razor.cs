using AutoMapper;
using EmployeeManagement.Client.Models;
using EmployeeManagement.Client.Services;
using EmployeeManagement.Shared;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        private Employee Employee{ get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IEmployeeService EmployeeService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDepartmentService DepartmentService{ get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        protected List<Department> Departments { get; set; } = new List<Department>();
        protected async void SubmitEditEmployeeForm()
        {
            Mapper.Map(EditEmployeeModel, Employee);

            Employee result = null;

            if(Employee.EmployeeId == 0)
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }



            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }

        }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if (employeeId == 0)
            {
                Employee = new Employee()
                {
                    DepartmentId = 1,
                    DateOfBrith = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };
            }
            else
            {
                Employee = await EmployeeService.GetEmployee(employeeId);
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();

            //EditEmployeeModel = Mapper.Map<Employee, EditEmployeeModel>(Employee);

            Mapper.Map(Employee, EditEmployeeModel);


            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail= Employee.Email;
            //EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department = Employee.Department;

        }
    }
}
