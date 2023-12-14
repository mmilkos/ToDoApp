using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Aplication.Services
{
    public class TodoApiService : ITodoApiService
    {
        private readonly ITodoApiRepository _todoApiRepository;
        public TodoApiService(ITodoApiRepository todoApiRepository)
        {
            _todoApiRepository = todoApiRepository;
        }
        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            var userTasks = await _todoApiRepository.GetAllTasksAsync();
            return userTasks;
        }
    }
}
