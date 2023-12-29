using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Domain.Interfaces
{
    public interface ITodoApiRepository
    {
        Task<IEnumerable<Domain.UserTask>> GetAllTasksAsync();
        Task<Domain.UserTask> AddTaskAsync(Domain.UserTask task);
        Task DeleteTaskAsync(int id);
        Task ChangeStatusAsync(int id);
        bool CheckIfObjectExistsById(int id);
    }
}
