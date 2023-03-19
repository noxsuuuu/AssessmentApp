using Microsoft.EntityFrameworkCore;
using AssessmentApp.Models;

namespace AssessmentApp.Data
{
    public static class SeedData
    {

        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>().HasData(
                new Department(1, "Accounting"),
                new Department(2, "Human Resource")
                );

            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    EmpName = "mark",
                    Id = 1,
                    EmpDob = DateTime.Now,
                    EmpEmail = "markbalagot05@gmail.com",
                    EmpPhone = "0134u21",
                    DepartmentId = 1
                }
                );

        }

    }
}


/*public static class SeedData
{



    public static void SeedDefaultData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                new User
                {
                    Name = "Administrator",
                    Id = 1,
                    DOB = DateTime.Now.AddYears(-20)
                });

        modelBuilder.Entity<Todo>().HasData(
            new Todo(1, "Shopping", "For Birthday", false, DateTime.Now.AddDays(1)),
            new Todo(2, "Learn C#", "In Jump Trainin", false, DateTime.Now.AddDays(2)),
            new Todo(3, "Learn MSSQL", "In Jump Trainin", false, DateTime.Now.AddDays(2))


            );
    }
}*/