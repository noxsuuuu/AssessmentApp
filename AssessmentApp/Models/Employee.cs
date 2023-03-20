using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AssessmentApp.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [DisplayName("Employee Name")]
        public int Id { get; set; }

        public string? EmpName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EmpDob { get; set; }
        [Display(Name = "Phone Number")]
        [MaxLength(11)]
        public string EmpPhone { get; set; }
        [Required]
        public string EmpEmail { get; set; }
        [Required(ErrorMessage = "Please Input Department Id")]
        public int DepartmentId { get; set; }

        [ValidateNever]
        public Department Department { get; set; }

        [NotMapped]
        [ValidateNever]
        public string DepartmentName { get; set; }

        public Employee()
        {

        }

        public Employee(int empId, string empName, DateTime empDob, string empPhone, string empEmail, int departmentId, string deptName)
        {
            Id = empId;
            EmpName = empName;
            EmpDob = empDob;
            EmpEmail = empEmail;
            EmpPhone = empPhone;
            DepartmentId = departmentId;     
            DepartmentName=deptName;
        }
    }
}
