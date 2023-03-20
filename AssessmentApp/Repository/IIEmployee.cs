using AssessmentApp.Models;

namespace AssessmentApp.Repository
{
    public interface IIEmployee
    {
        List<Department> GetInAllDept();

        List<Employee> GetInAllEmp();

        Department GetInDeptById(int deptID);

        Employee GetInEmpById(int empID);

        Employee AddInMemoryEmp(Employee newEmp);

        Employee UpdateInMemoryEmp(int empID, Employee newEmp);

        Employee DeleteInMemoryEmp(int empID);
    }
}
