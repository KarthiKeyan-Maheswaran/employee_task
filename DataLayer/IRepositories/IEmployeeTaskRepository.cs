using EntityLayer;

using System.Collections.Generic;

namespace DataLayer
{
    public interface IEmployeeTaskRepository
    {
        IEnumerable<EmployeeTask> Get();
        EmployeeTask Get(string ID);
        EmployeeTask Get(int ID);
        EmployeeTask CreateEmpty();
        IEnumerable<EmployeeTask> GetEmployeewise(string ID);

        void Add(EmployeeTask entity);
        void Update(EmployeeTask entity);
        bool Delete(int id);
        void Save();
    }
}
