using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ToDoAPI.Entites
{
    public class ToDoDbContext:DbContext
    {
        private string _connectionstring =
            "Server=localhost;Database=ToDoDb;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.HashPassword)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<Task>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Task>()
                .Property(t => t.IsDone)
                .IsRequired()
                .HasDefaultValue(false);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }
    }
}
