using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SignUpWebAPI.Models
{
    public class UserApiDbContext : DbContext
    {
        public DbSet<UserModel> UserModel { get; set; }

        public UserApiDbContext(DbContextOptions<UserApiDbContext> options) : base(options)
        {

        }

    }
}
