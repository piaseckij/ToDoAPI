using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Route("api/ToDo")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public ToDoController(ITasksService tasksService)
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
            var id = _tasksService.CreateTask(dto);

            return Created($"api/ToDo/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _tasksService.Remove(id);

            return NoContent();
        }
    }
}