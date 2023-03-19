using AssessmentApp.Data;
using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Repository.MsSQL
{
    public class EmpDBRepository : IEmployee
    {
        EMSDbContext _dbContext;


        public EmpDBRepository(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Department> GetAllDept()
        {
            return _dbContext.Departments.ToList<Department>();
        }

        public List<Employee> GetAllEmp()
        {

            var emp = _dbContext.Employees.Include(e => e.Department).ToList();

            foreach(var employee in emp)
            {
                employee.DepartmentName = employee.Department?.DeptName;
            }

            return emp;
        }

        public Department GetDeptById(int Id)
        {
            return _dbContext.Departments.AsNoTracking().FirstOrDefault(t => t.Id == Id);
        }


        public Employee GetEmpById(int Id)
        {
            return _dbContext.Employees.AsNoTracking().FirstOrDefault(t => t.Id == Id);
        }

        public Employee AddEmp(Employee newEmp)
        {

            _dbContext.Add(newEmp);
            _dbContext.SaveChanges();

            return newEmp;
        }


        public Employee DeleteEmp(int empID)
        {
            var emp = GetEmpById(empID);

            if (emp != null)
            {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
            }

            return emp;
        }

        public Employee UpdateEmp(int empID, Employee newEmp)
        {
            var oldEmp = GetEmpById(empID);

            if (oldEmp != null)
            {

                _dbContext.Employees.Update(newEmp);
                _dbContext.SaveChanges();
            }
            return newEmp;
        }

     
    }
}
