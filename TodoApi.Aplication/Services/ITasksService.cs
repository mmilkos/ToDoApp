using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Dtos;

namespace TodoApi.Aplication.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<Domain.Entities.UserTask>> GetAllTasksAsync();
        Task<TaskDto> AddTaskAsync(TaskFormDto tasykJson);
        Task DeleteTaskAsync(int id);

        Task ChangeStatusAsync(int id);

        bool CheckIfTaskExistsById(int id);
    }
}
