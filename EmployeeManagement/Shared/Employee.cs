using EmployeeManagement.Shared.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="FirstName is mandatory")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        
        [EmailDomainValidator(AllowedDomain = "pragimtech.com")]
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string? PhotoPath { get; set; }
    }
}
