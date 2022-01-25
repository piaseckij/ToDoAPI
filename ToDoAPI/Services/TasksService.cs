using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using ToDoAPI.Entites;
using ToDoAPI.Exceptions;
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
        private readonly ToDoDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public TasksService(ToDoDbContext dbContext, IMapper mapper, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public TaskDto GetById(int id)
        {
            var task = getTaskById(id);

            var taskDto = _mapper.Map<TaskDto>(task);

            return taskDto;
        }

        public IEnumerable<TaskDto> GetAll()
        {
            var tasks = _dbContext
                .Tasks.Where(c=>c.UserId==_userContextService.GetUserId)
                .ToList();


            var tasksDto = _mapper.Map<List<TaskDto>>(tasks);
            return tasksDto;
        }

        public int CreateTask(CreateTaskDto dto)
        {
            var task = _mapper.Map<Task>(dto); 

            task.UserId = _userContextService.GetUserId;

            _dbContext.Add((object) task);
            _dbContext.SaveChanges();

            return task.Id;
        }

        public void Remove(int id)
        {
            var task = getTaskById(id);

            _dbContext.Remove(task);
            _dbContext.SaveChanges();
        }

        private Task getTaskById(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id&& t.UserId==_userContextService.GetUserId);

            if (task is null)
                throw new NotFoundException("Task not found");

            return task;
        }
    }
}