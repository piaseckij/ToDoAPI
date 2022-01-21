using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Entites;
using ToDoAPI.Models;
using ToDoAPI.Services;
using Task = System.Threading.Tasks.Task;

namespace ToDoAPI.Controllers
{
    [Route("api/ToDo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TasksService _tasksService;

        public ToDoController(TasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> Get([FromRoute] int id)
        {
            var tasks = _tasksService.GetAll();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetById([FromRoute] int id)
        {
            var task = _tasksService.GetById(id);

            return Ok(task);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateTaskDto dto)
        {
            int id=_tasksService.CreateTask(dto);

            return Created($"api/ToDo/{id}",null);
        }
}
}
