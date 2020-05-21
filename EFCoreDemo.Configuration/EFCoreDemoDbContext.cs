using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Configuration
{
    public class EFCoreDemoDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.1.23;Database=EFCoreDemoDB;Trusted_Connection=True;");
        }
    }
}
