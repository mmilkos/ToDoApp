using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using TodoApi.Aplication.Services;
using TodoApi.Domain.Dtos;
using TodoApi.Domain.Entities;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/tasks")] 
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;

        }

        [HttpGet] // /api/tasks
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetAllTasksAsync()
        {
            IEnumerable<UserTask> tasks = await _tasksService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpPost] // api/tasks
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<TaskDto>> AddTaskAsync([FromBody] TaskFormDto formDto)
        {
            if (ModelState.IsValid)
            {
                var task = await _tasksService.AddTaskAsync(formDto);
                return StatusCode(201, task);
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")] // api/tasks/id
        public async Task<ActionResult> ChangeStatusAsync(int id)
        {
            bool exist = _tasksService.CheckIfTaskExistsById(id);
            if (exist)
            {
                await _tasksService.ChangeStatusAsync(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")] // api/tasks/id
        public async Task<ActionResult> DeleteTaskAsync(int id)
        {
            bool exist = _tasksService.CheckIfTaskExistsById(id);
            if (exist)
            {
                await _tasksService.DeleteTaskAsync(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }   
        }
    }
}
