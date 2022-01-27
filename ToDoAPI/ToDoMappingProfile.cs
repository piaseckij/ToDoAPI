using AutoMapper;
using ToDoAPI.Entities;
using ToDoAPI.Models;

namespace ToDoAPI
{
    public class ToDoMappingProfile : Profile
    {
        public ToDoMappingProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<TaskDto, Task>();

            CreateMap<CreateTaskDto, Task>();
        }
    }
}