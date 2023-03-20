using AssessmentApp.Models;

namespace AssessmentApp.Repository
{
    public interface IIDepartment
    {

        List<Department> GetInAllDept();

        Department GetInDeptById(int deptID);

        Department AddInMemoryDept(Department newDept);

        Department UpdateInMemoryDept(int deptID, Department newDept);

        Department DeleteInMemoryDept(int deptID);
    }
}
