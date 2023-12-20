using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain;

namespace TodoApi.Aplication.Services
{
    public interface ITodoApiService
    {
        Task<IEnumerable<UserTask>> GetAllTasksAsync();
        Task<Domain.UserTask> AddTaskAsync(FormModelDto tasykJson);
        Task DeleteTaskAsync(int id);

        Task ChangeStatusAsync(int id);
    }
}
