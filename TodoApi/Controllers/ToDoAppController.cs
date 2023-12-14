using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<UserTask>> GetAllTasksAsync() 
        {
            var tasks = await _todoApiService.GetAllTasksAsync();
            return tasks;
        }
    }
}
