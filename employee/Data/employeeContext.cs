using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace employee.Models
{
    public class employeeContext : DbContext
    {
        public employeeContext (DbContextOptions<employeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> employeesData { get; set; }
    }
}
