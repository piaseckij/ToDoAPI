using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Entities
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

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
    }
}