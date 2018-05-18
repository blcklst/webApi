using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.Models;

namespace user.Models
{
    public class userContext : DbContext
    {
        public userContext (DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public DbSet<User.Models.User> Users { get; set; }
    }
}
