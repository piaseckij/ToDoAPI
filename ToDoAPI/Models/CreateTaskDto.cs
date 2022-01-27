using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class CreateTaskDto
    {
        [MaxLength(30)] [Required] public string Name { get; set; }

        public string Description { get; set; }
    }
}