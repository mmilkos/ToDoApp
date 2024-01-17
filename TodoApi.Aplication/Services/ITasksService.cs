using Microsoft.AspNetCore.Http;
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
        Task<IEnumerable<Domain.Entities.UserTask>> GetUserTasksAsync(string name);
        Task<TaskDto> AddTaskAsync(TaskFormDto tasykJson, string name);
        Task DeleteTaskAsync(int id);

        Task ChangeStatusAsync(int id);

        bool DoesTaskExist(int id);

        string GetUserNameFromJwt(string jwt);

        bool IsAuthorizationHeaderValid(IHeaderDictionary headers);
    }
}
