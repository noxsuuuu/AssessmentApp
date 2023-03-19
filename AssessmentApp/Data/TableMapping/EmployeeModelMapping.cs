using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Data.TableMapping
{
    public static class EmployeeModelMapping
    {
        public static void EmployeeTableMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpName)
                .IsRequired()
                .HasColumnName("Name");

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpDob)
                .IsRequired()
                .HasColumnName("Birthday");

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpEmail)
                .IsRequired()
                .HasColumnName("Email");

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpPhone)
                .IsRequired()
                .HasColumnName("Phone Number");

            modelBuilder.Entity<Employee>()
                .Property(e => e.DepartmentId)
                .IsRequired()
                .HasColumnName("Department Id");

        }

    }
}
