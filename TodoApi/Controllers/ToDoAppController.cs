using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using TodoApi.Aplication.Services;
using TodoApi.Domain;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/tasks")] 
    public class ToDoAppController : ControllerBase
    {
        private readonly ITodoApiService _todoApiService;
        public ToDoAppController(ITodoApiService todoApiService)
        {
            _todoApiService = todoApiService;
        }

        [HttpGet] // /api/tasks
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetAllTasksAsync()
        {
            IEnumerable<UserTask> tasks = await _todoApiService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpPost] // api/tasks
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<Domain.UserTaskResponse>> AddTaskAsync([FromBody] FormModelDto formDto)
        {
            if (ModelState.IsValid)
            {
                var task = await _todoApiService.AddTaskAsync(formDto);
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
            bool exist = _todoApiService.CheckIfTaskExistsById(id);
            if (exist)
            {
                await _todoApiService.ChangeStatusAsync(id);
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
            bool exist = _todoApiService.CheckIfTaskExistsById(id);
            if (exist)
            {
                await _todoApiService.DeleteTaskAsync(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }   
        }
    }
}
