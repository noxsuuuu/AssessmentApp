using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AssessmentApp.Models
{
    public class Department
    {
        [DisplayName("Department ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Department Name")]
        [DisplayName("Department Name")]
        public string DeptName { get; set; }


        [ValidateNever]
        public ICollection<Employee>? Employees { get; set; }



        public Department()
        {

        }


        public Department(int deptId, string deptName)
        {
            Id = deptId;
            DeptName = deptName;
        }

    }

   
}

