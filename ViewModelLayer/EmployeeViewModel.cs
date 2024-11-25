using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModelLayers
{
    public class EmployeeViewModel
    {
        public IEmployeeRepository Repository { get; set; }

        public IEnumerable<Employee> AllEmployees { get; set; }

        public EmployeeLogin EmployeeLogin { get; set; }

        public Employee Employee { get; set; }

        public Employee CheckUserLogin(string employeecode, string password)
        {
            if (Repository == null)
            {
                throw new ApplicationException(
                  "Must set the Repository property.");
            }
            else
            {
                return Employee = Repository.CheckUserLogin(employeecode, password);
            }
        }

        public void LoadEmployees()
        {
            if (Repository == null)
            {
                throw new ApplicationException("Must set the Repository property.");
            }
            else
            {
                AllEmployees = Repository.Get().OrderBy(p => p.EmployeeName).ToList();
            }
        }

        public void LoadEmployee(string id)
        {
            if (Repository == null)
            {
                throw new ApplicationException(
                  "Must set the Repository property.");
            }
            else
            {
                Employee = Repository.Get(id);
            }
        }


        public void LoadEmployeewise(string id)
        {
            if (Repository == null)
            {
                throw new ApplicationException(
                  "Must set the Repository property.");
            }
            else
            {
                Employee = Repository.Get(id);
            }
        }

        public void CreateEmptyEmployee()
        {
            Employee = Repository.CreateEmpty();
        }

        public bool SaveOrUpdate()
        {
            if (Repository == null)
            {
                throw new ApplicationException(
                  "Must set the Repository property.");
            }
            else
            {
                if (Employee.EmployeeId > 0)
                {
                   
                    Repository.Update(Employee);
                    SaveChanges();
                    return true;
                }
                else
                {
                   
                    Employee.CreatedOn = DateTime.Now;
                    Repository.Add(Employee); SaveChanges();
                    CreateandUpdateEmployeeCode();
                    return false;
                }
            }
        }

        public void CreateandUpdateEmployeeCode()
        {
            if (Repository == null)
            {
                throw new ApplicationException(
                  "Must set the Repository property.");
            }
            else
            {
                int lastEmployeeId = Repository.GetMaxID();
                var employee = Repository.Get(Employee.EmployeeId);
                if (employee != null)
                {
                    employee.EmployeeCode = "E" + lastEmployeeId.ToString();
                    SaveChanges();
                }
            }
        }

        public bool DeleteEmployee(int id)
        {
            if(id > 0)
            {
                Repository.Delete(id);
                SaveChanges();
                return true;
            }

            return false;
        }

        protected void SaveChanges()
        {
            Repository.Save();
        }
    }
}
