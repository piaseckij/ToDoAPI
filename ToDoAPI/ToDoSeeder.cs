using System.Collections.Generic;
using System.Linq;
using ToDoAPI.Entites;

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
                if (!_context.Tasks.Any())
                {
                    var tasks = GetTasks();
                    _context.Tasks.AddRange(tasks);
                    _context.SaveChanges();
                }
        }

        private IEnumerable<Task> GetTasks()
        {
            var tasks = new List<Task>
            {
                new()
                {
                    Name = "Finish this project",
                    Description = "I should finally finish this API"
                },

                new()
                {
                    Name = "Meet friends",
                    Description = "Meet Friends at 19:00"
                }
            };

            return tasks;
        }
    }
}