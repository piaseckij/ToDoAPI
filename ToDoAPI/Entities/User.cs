using System.Collections.Generic;

namespace ToDoAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public List<Task> Tasks { get; set; }
    }
}