
using EntityLayer;
using System.Data.Entity;

namespace DataLayer
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("name=SQLConnection")
        {

        }

        // Table Names

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }

    }
}
