using EmployeeManagement.Shared.ValidationAttributes;
using EmployeeManagement.Shared;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Client.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "FirstName is mandatory")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "pragimtech.com", ErrorMessage ="Only PragimTech.com is allowed")]
        public string Email { get; set; }
        [Compare("Email", ErrorMessage = "Email and ConfirmEmail are not equal")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string PhotoPath { get; set; }
    }
}
