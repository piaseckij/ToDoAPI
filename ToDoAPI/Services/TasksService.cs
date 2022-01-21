using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ToDoAPI.Entites;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface ITasksService
    {
        TaskDto GetById(int id);
        IEnumerable<TaskDto> GetAll();
        int CreateTask(CreateTaskDto dto);
        void Remove(int id);
    }

    public class TasksService : ITasksService
    {
        private readonly ToDoDbContext _context;
        private readonly IMapper _mapper;

        public TasksService(ToDoDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public TaskDto GetById(int id)
        {
            var task = _context
                .Tasks
                .FirstOrDefault(t => t.Id == id);

            var taskDto=_mapper.Map<TaskDto>(task);
                
            //ToDo throw new exception
            //if (task is null)

            return taskDto;
        }

        public IEnumerable<TaskDto> GetAll()
        {
            var tasks=_context
                .Tasks
                .ToList();

            var tasksDto = _mapper.Map<List<TaskDto>>(tasks);
            return tasksDto;
        }

        public int CreateTask(CreateTaskDto dto)
        {
            var task = _mapper.Map<Task>(dto);

            _context.Add(task);
            _context.SaveChanges();

            return task.Id;

        }

        public void Remove(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            _context.Remove(task);
            _context.SaveChanges();

        }

    }
}