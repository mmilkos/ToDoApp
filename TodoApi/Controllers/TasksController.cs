using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<UserTask>>> GetUserTasksAsync()
        {
            var headers = HttpContext.Request.Headers;
            bool isValid = _tasksService.IsAuthorizationHeaderValid(headers);

            if (!isValid) { return Unauthorized(); }

            string jwtToken = headers["Authorization"].ToString().Split(' ', 2)[1];
            string userName = _tasksService.GetUserNameFromJwt(jwtToken);
            IEnumerable<UserTask> userTasks = await _tasksService.GetUserTasksAsync(userName);

            return Ok(userTasks);
        }

        [HttpPost] // api/tasks
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<TaskDto>> AddTaskAsync([FromBody] TaskFormDto formDto)
        {
            var headers = HttpContext.Request.Headers;
            bool isValid = _tasksService.IsAuthorizationHeaderValid(headers);

            if (!isValid) { return Unauthorized(); }

            if (!ModelState.IsValid){ return BadRequest(); }

            string jwt = headers["Authorization"].ToString().Split(' ')[1];
            string userName = _tasksService.GetUserNameFromJwt(jwt);
            var newTask = await _tasksService.AddTaskAsync(formDto, userName);

            return StatusCode(201, newTask);
        }

        [HttpPut("{taskId}")] // api/tasks/id
        public async Task<ActionResult> ChangeStatusAsync(int taskId)
        {
            var headers = HttpContext.Request.Headers;
            bool isAuthorizationValid = _tasksService.IsAuthorizationHeaderValid(headers);

            if (!isAuthorizationValid) { return Unauthorized(); }

            bool exist = _tasksService.DoesTaskExist(taskId);

            if (!exist) { return NotFound(); }

            await _tasksService.ChangeStatusAsync(taskId);

            return Ok();
        }

        [HttpDelete("{taskId}")] // api/tasks/id
        public async Task<ActionResult> DeleteTaskAsync(int taskId)
        {
            var headers = HttpContext.Request.Headers;
            bool isAuthorizationValid = _tasksService.IsAuthorizationHeaderValid(headers);

            if (!isAuthorizationValid) { return Unauthorized(); }

            bool exist = _tasksService.DoesTaskExist(taskId);
            
            if (!exist){ return NotFound(); }

            await _tasksService.DeleteTaskAsync(taskId);
            return Ok();      
        }
    }
}
