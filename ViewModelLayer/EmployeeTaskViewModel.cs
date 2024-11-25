using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModelLayers
{
    public class EmployeeTaskViewModel
    {
        public IEmployeeTaskRepository Repository { get; set; }

        public IEnumerable<EmployeeTask> AllEmployeeTasks { get; set; }

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public EmployeeTask EmployeeTask { get; set; }

   
        public void LoadEmployeeTasks()
        {
            if (Repository == null)
            {
                throw new ApplicationException("Must set the Repository property.");
            }
            else
            {
                AllEmployeeTasks = Repository.Get().OrderBy(p => p.TaskID).ToList();
                
            }
        }

        public void LoadEmployeeTask(string id)
        {
            if (Repository == null)
            {
                throw new ApplicationException(
                  "Must set the Repository property.");
            }
            else
            {
                EmployeeTask = Repository.Get(id);
                Employees = EmployeeRepository.Get().OrderBy(p => p.EmployeeId).ToList();
            }
        }


        public void LoadEmployeewiseTask(string id)
        {
            if (Repository == null)
            {
                throw new ApplicationException(
                  "Must set the Repository property.");
            }
            else
            {
                AllEmployeeTasks = Repository.GetEmployeewise(id).OrderBy(p => p.TaskID).ToList();

            }
        }


        public void CreateEmptyEmployeeTask()
        {
            EmployeeTask = Repository.CreateEmpty(); 
            Employees = EmployeeRepository.Get().OrderBy(p => p.EmployeeId).ToList();
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
                if (EmployeeTask.TaskID > 0)
                {
                    
                    Repository.Update(EmployeeTask);
                    SaveChanges();
                    return true;
                }
                else
                {
                    
                    EmployeeTask.CreatedOn = DateTime.Now;
                    Repository.Add(EmployeeTask); SaveChanges();
      
                    return false;
                }
            }
        }


        public bool DeleteEmployeeTask(int id)
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
