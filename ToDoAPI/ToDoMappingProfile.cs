using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ToDoAPI.Models;
using ToDoAPI.Entites;

namespace ToDoAPI
{
    public class ToDoMappingProfile:Profile
    {
        public ToDoMappingProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<TaskDto, Task>();

            CreateMap<CreateTaskDto, Task>();

        }
    }
}
