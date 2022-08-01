using EmployeeCrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudApp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }


    }
}
