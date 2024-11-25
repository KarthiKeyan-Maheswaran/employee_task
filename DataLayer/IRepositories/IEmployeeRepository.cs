using EntityLayer;

using System.Collections.Generic;

namespace DataLayer
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Employee Get(string ID);
        Employee Get(int ID);
        Employee CreateEmpty();
        Employee CheckUserLogin(string employeecode, string password);
        int GetMaxID();
        void Add(Employee entity);
        void Update(Employee entity);
        bool Delete(int id);
        void Save();
    }
}
