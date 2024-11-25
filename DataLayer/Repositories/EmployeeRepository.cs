using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer
{
    public partial class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public EmployeeRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IEnumerable<Employee> Get()
        { 
            return _dbContext.Employees.Where(a=>a.EmployeeId!=1).ToList();
        }

        public Employee Get(string EmployeeCode)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.EmployeeCode == EmployeeCode);
        }

        public Employee Get(int ID)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == ID);
        }

        public Employee CheckUserLogin(string employeecode, string password)
        {
            return _dbContext.Employees.Where(u => u.EmployeeCode == employeecode
                && u.Password == password).SingleOrDefault();
        }

        public int GetMaxID()
        {
            return _dbContext.Employees.Max(item => item.EmployeeId);
        }

        public void Add(Employee entity)
        {
            _dbContext.Employees.Add(entity);
        }

        public void Update(Employee entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                return true;
            }

            return false;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Employee CreateEmpty()
        {
            return new Employee
            {
                EmployeeName = string.Empty,
                EmployeeCode = string.Empty,
                Age = 0,
                DOJ = DateTime.Now,
                Department = string.Empty,
                Designation = string.Empty,
                Salary = 0,
                Password = string.Empty
            };
        }
    }
}
