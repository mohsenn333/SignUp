using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SignUp.Models
{
    public class UserAppContext : DbContext
    {
        public DbSet<UserModel> UserModel { get; set; }

        public UserAppContext(DbContextOptions<UserAppContext> options) : base(options)
        {

        }
        
    }
}
