using EmpDepApi.Models;
using System.Data.Entity;

namespace EmpDepApi.Context
{
    public class EmpresaContext : DbContext
    {
        public EmpresaContext() : base("DB")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}