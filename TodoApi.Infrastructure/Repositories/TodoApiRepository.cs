using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure.Repositories
{
    public class TodoApiRepository : ITodoApiRepository
    {
        private readonly ToDoAppDbContext _DbContext;
        public TodoApiRepository(ToDoAppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task AddTaskAsync(UserTask task)
        {
           await _DbContext.Tasks.AddAsync(task);
           await _DbContext.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            var allTasks = await _DbContext.Tasks.ToListAsync();
            return allTasks;
        }
    }
}
