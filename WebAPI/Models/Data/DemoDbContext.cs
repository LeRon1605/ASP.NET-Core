using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Entity;

namespace WebAPI.Models.Data
{
    public class DemoDbContext: DbContext
    {

        public DemoDbContext(DbContextOptions options): base(options)
        {

        }    

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
