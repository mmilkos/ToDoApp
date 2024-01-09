using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces
{
    public interface ITasksRepository
    {
        Task<IEnumerable<UserTask>> GetUserTasksAsync(string name);
        Task<UserTask> AddTaskAsync(UserTask task);
        Task DeleteTaskAsync(int id);
        Task ChangeStatusAsync(int id);
        bool DoesTaskExist(int id);
    }
}
