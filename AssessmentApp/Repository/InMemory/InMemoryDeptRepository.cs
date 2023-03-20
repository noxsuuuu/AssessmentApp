using AssessmentApp.Models;

namespace AssessmentApp.Repository.InMemory
{
    public class InMemoryDeptRepository : IIDepartment
    {

        static List<Department> departmentList = new List<Department>();
        public Department AddInMemoryDept(Department newDept)
        {
            newDept.Id = departmentList.Max(x => x.Id) + 1;
            departmentList.Add(newDept);
            return newDept;
        }

        public Department DeleteInMemoryDept(int deptID)
        {
            var oldDept = departmentList.Find(x => x.Id == deptID);
            if (oldDept == null)

                return null;

            departmentList.Remove(oldDept);

            return oldDept;

        }


        /*static TodoInMemoryRepository()
        {
            todoList.Add(new Todo(1, "Shopping", "For Birthday", false, DateTime.Now.AddDays(1)));
            todoList.Add(new Todo(2, "Learn C#", "In Jump Trainin", false, DateTime.Now.AddDays(2)));
            todoList.Add(new Todo(3, "Learn MSSQL", "In Jump Trainin", false, DateTime.Now.AddDays(2)));
        }*/



        public List<Department> GetInAllDept()
        {
            return departmentList;
        }

       
        public Department GetInDeptById(int deptID)
        {
            return departmentList.FirstOrDefault(x => x.Id == deptID);
        }

  

        public Department UpdateInMemoryDept(int deptID, Department newDept)
        {
            var oldDept = departmentList.Find(x => x.Id == deptID);
            if (oldDept != null)
            {
                return null;
            }
            departmentList.Remove(oldDept);
            departmentList.Add(newDept);
            return newDept;
        }
    }
}
