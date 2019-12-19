using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCORE
{
    public class AppContext:DbContext
    {   
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCOREdb;Trusted_Connection=True;");
        }
    }
}
