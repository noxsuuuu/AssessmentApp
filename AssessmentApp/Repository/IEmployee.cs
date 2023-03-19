using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Repository
{
    public interface IEmployee
    {
        List<Department> GetAllDept();
        
        List<Employee> GetAllEmp();

        Department GetDeptById(int deptID);

        Employee GetEmpById(int empID);

        Employee AddEmp(Employee newEmp);

        Employee UpdateEmp(int empID, Employee newEmp);

        Employee DeleteEmp(int empID);



    }
}
