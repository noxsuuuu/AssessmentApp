using AssessmentApp.Models;

namespace AssessmentApp.Repository.InMemory
{
    public class InMemoryEmpRepository : IIEmployee
    {

        static List<Employee> empList = new List<Employee>();
        static List<Department> departmentList = new List<Department>();

        /*static TodoInMemoryRepository()
        {
            todoList.Add(new Todo(1, "Shopping", "For Birthday", false, DateTime.Now.AddDays(1)));
            todoList.Add(new Todo(2, "Learn C#", "In Jump Trainin", false, DateTime.Now.AddDays(2)));
            todoList.Add(new Todo(3, "Learn MSSQL", "In Jump Trainin", false, DateTime.Now.AddDays(2)));
        }*/

        public Employee AddInMemoryEmp(Employee newEmp)
        {
            newEmp.Id = empList.Max(x => x.Id) + 1;
            empList.Add(newEmp);
            return newEmp;
        }

        public Employee DeleteInMemoryEmp(int empID)
        {
           var oldEmp = empList.Find(x=>x.Id == empID);
            if (oldEmp == null)
            
                return null;
            
            empList.Remove(oldEmp);

            return oldEmp;

        }

        public List<Department> GetInAllDept()
        {
            return departmentList;
        }

        public List<Employee> GetInAllEmp()
        {

            return empList;
        }

        public Department GetInDeptById(int deptID)
        {
            return departmentList.FirstOrDefault(x => x.Id == deptID);
        }

        public Employee GetInEmpById(int empID)
        {
            return empList.FirstOrDefault(x => x.Id == empID);
        }

        public Employee UpdateInMemoryEmp(int empID, Employee newEmp)
        {
            var oldEmp = empList.Find(x=>x.Id == empID);
            if (oldEmp != null)
                return null;
            

            empList.Remove(oldEmp); 
            empList.Add(newEmp);
            return newEmp;
        }
    }
}

