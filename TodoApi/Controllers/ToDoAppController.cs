using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using TodoApi.Aplication.Services;
using TodoApi.Domain;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/tasks")] // /api/tasks
    public class ToDoAppController : ControllerBase
    {
        private readonly ITodoApiService _todoApiService;
        public ToDoAppController(ITodoApiService todoApiService)
        {
            _todoApiService = todoApiService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            var tasks = await _todoApiService.GetAllTasksAsync();
            return tasks;
        }

        [HttpPost("sendTask")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<Domain.UserTask> AddTaskAsync([FromBody] FormModelDto formDto)
        {

            return await _todoApiService.AddTaskAsync(formDto);

        }

        [HttpDelete("deleteTask/{id}")]
        public async Task DeleteTaskAsync(int id)
        {
            await _todoApiService.DeleteTaskAsync(id);
        }


    }
}
