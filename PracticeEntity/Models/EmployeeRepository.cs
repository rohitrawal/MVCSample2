using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeEntity.Models
{
    public class EmployeeRepository
    {
        EmployeeDBContext employeeDBContext = new EmployeeDBContext();
        public List<Department> GetDepartments()
        {
            return employeeDBContext.Departments.Include("Employees").ToList();
        }

        public List<Employee> GetEmployees()
        {
            return employeeDBContext.Employees.ToList();
        }

        public void InsertEmployee(Employee employee)
        {
            employeeDBContext.Employees.Add(employee);
            employeeDBContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            Employee employeeToUpdate = employeeDBContext
                .Employees.SingleOrDefault(x => x.Id == employee.Id);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.Gender = employee.Gender;
            employeeToUpdate.Salary = employee.Salary;
            employeeDBContext.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            Employee employeeToDelete = employeeDBContext
                .Employees.SingleOrDefault(x => x.Id == employee.Id);
            employeeDBContext.Employees.Remove(employeeToDelete);
            employeeDBContext.SaveChanges();
        }
    }
}