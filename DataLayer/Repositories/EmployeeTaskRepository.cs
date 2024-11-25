using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer
{
    public partial class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public EmployeeTaskRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IEnumerable<EmployeeTask> Get()
        {
            return _dbContext.EmployeeTasks.ToList();
        }

        public EmployeeTask Get(string EmployeeTaskCode)
        {
            return _dbContext.EmployeeTasks.FirstOrDefault(e => e.TaskID.ToString() == EmployeeTaskCode);
        }

        public EmployeeTask Get(int ID)
        {
            return _dbContext.EmployeeTasks.FirstOrDefault(e => e.TaskID == ID);
        }


        public void Add(EmployeeTask entity)
        {
            _dbContext.EmployeeTasks.Add(entity);
        }

        public void Update(EmployeeTask entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var EmployeeTask = _dbContext.EmployeeTasks.Find(id);

            if (EmployeeTask != null)
            {
                _dbContext.EmployeeTasks.Remove(EmployeeTask);
                return true;
            }

            return false;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public EmployeeTask CreateEmpty()
        {
            return new EmployeeTask
            {
                TaskName = string.Empty,
                EmployeeCode = string.Empty,
                TaskStatus = string.Empty,
                TaskDescription = string.Empty
 
            };
        }

    
        public IEnumerable<EmployeeTask> GetEmployeewise(string ID)
        {
            return _dbContext.EmployeeTasks.Where(e => e.EmployeeCode == ID).ToList();
        }

    }
}
