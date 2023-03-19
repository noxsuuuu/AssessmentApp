using AssessmentApp.Models;

namespace AssessmentApp.Repository
{
    public interface IDepartment
    {
        List<Department> GetAllDept();

        Department GetDeptById(int deptID);

        Department AddDept(Department newDept);

        Department UpdateDept(int deptID, Department newDept);

        Department DeleteDept(int deptID);

    }
}
