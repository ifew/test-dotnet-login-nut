using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
