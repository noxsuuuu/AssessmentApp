using AssessmentApp.Data;
using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;


namespace AssessmentApp.Repository.MsSQL
{
    public class DeptDBRepository : IDepartment
    {


        EMSDbContext _dbContext;


        public DeptDBRepository(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Department> GetAllDept()
        {
            return _dbContext.Departments.ToList<Department>();
        }
        public Department GetDeptById(int Id)
        {
            return _dbContext.Departments.AsNoTracking().FirstOrDefault(t => t.Id == Id);
        }

        public Department AddDept(Department newDept)
        {


            _dbContext.Add(newDept);
            _dbContext.SaveChanges();

            return newDept;
        }


        public Department DeleteDept(int deptID)
        {
            var dept = GetDeptById(deptID);

            if(dept != null)
            {
                _dbContext.Departments.Remove(dept);
                _dbContext.SaveChanges();
            }

            return dept;
        }

        public Department UpdateDept(int deptID,  Department newDept)
        {
            var oldDept = GetDeptById(deptID);

            if(oldDept != null)
            {
                _dbContext.Departments.Update(newDept);
                _dbContext.SaveChanges();
            }
            return newDept;
        }

  
    }
}
