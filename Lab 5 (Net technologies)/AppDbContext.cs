using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Lab_5__Net_technologies_
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=7217025;database=lab5db;",
                new MySqlServerVersion(new Version(8, 3, 0))
            );
        }
    }
}