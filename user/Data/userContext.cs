using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace user.Models
{
    public class userContext : DbContext
    {
        public userContext (DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public DbSet<Users.Models.Users> Users { get; set; }
    }
}
