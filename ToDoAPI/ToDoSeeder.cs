using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;

namespace ToDoAPI
{
    public class ToDoSeeder
    {
        private readonly ToDoDbContext _context;

        public ToDoSeeder(ToDoDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                var pendingMigrations = _context.Database.GetPendingMigrations();

                if (pendingMigrations != null && pendingMigrations.Any()) _context.Database.Migrate();

                if (!_context.Users.Any())
                {
                    var user = new User
                    {
                        Email = "test@test.com",
                        HashPassword = "password1",
                        Username = "test"
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }

                if (!_context.Tasks.Any())
                {
                    var tasks = GetTasks();
                    _context.Tasks.AddRange(tasks);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Task> GetTasks()
        {
            var tasks = new List<Task>
            {
                new()
                {
                    Name = "Finish this project",
                    Description = "I should finally finish this API",
                    UserId = 1
                },

                new()
                {
                    Name = "Meet friends",
                    Description = "Meet Friends at 19:00",
                    UserId = 1
                }
            };

            return tasks;
        }
    }
}