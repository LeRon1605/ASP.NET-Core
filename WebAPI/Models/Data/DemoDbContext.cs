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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(user => user.Course)
                      .WithMany(course => course.Users)
                      .HasForeignKey(user => user.CourseID)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(user => user.Role)
                      .WithMany(role => role.Users)
                      .HasForeignKey(user => user.RoleID)
                      .OnDelete(DeleteBehavior.SetNull);
            });

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
