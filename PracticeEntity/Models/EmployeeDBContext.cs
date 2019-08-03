using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticeEntity.Models
{
    // EmployeeDBContext class must inherit from DbContext
    // present in System.Data.Entity namespace
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .MapToStoredProcedures(p => p.Insert(x => x.HasName("InsertEmployee")));
            modelBuilder.Entity<Employee>()
                .MapToStoredProcedures(p => p.Update(x => x.HasName("UpdateEmployee")));
            modelBuilder.Entity<Employee>()
                .MapToStoredProcedures(p => p.Delete(x => x.HasName("DeleteEmployee")));

            base.OnModelCreating(modelBuilder);
        }
    }
}