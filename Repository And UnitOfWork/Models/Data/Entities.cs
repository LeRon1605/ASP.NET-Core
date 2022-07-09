using FirstProject_MVC.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject_MVC.Models.Data
{
    public class Entities: IdentityDbContext<User>
    {
        //private string ConnectionString = "Server=localhost,1433;Database=FirstProject;UID=sa;PWD=ronle75";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer(ConnectionString);   
        //}
        public Entities(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityTypes in modelBuilder.Model.GetEntityTypes())
            {
                if (entityTypes.GetTableName().StartsWith("AspNet"))
                {
                    entityTypes.SetTableName(entityTypes.GetTableName().Substring(6));
                }    
            }    
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
