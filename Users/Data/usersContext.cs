using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Users.Models
{
    public class usersContext : DbContext
    {
        public usersContext(DbContextOptions<usersContext> options)
            : base(options)
        {
        }

        public DbSet<usersContext> Users { get; set; }
    }
}
