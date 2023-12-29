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

        public async Task<UserTask> AddTaskAsync(UserTask task)
        {
           await _DbContext.Tasks.AddAsync(task);
           await _DbContext.SaveChangesAsync();
           return task;
           
        }

        public async Task ChangeStatusAsync(int id)
        {
            UserTask userTask = await _DbContext.Tasks.FindAsync(id);
            if (userTask != null) 
            {
                bool status = userTask.Complited;
                userTask.Complited = !status;
                await _DbContext.SaveChangesAsync();
            }
        }

        public bool CheckIfObjectExistsById(int id)
        {
            bool exist =  _DbContext.Tasks.Any(task => task.Id == id);
            return exist;
        }

        public async Task DeleteTaskAsync(int id)
        {
            UserTask userTask = await _DbContext.Tasks.FindAsync(id);
            if (userTask != null)
            {
                _DbContext.Tasks.Remove(userTask);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            var allTasks = await _DbContext.Tasks.ToListAsync();
            return allTasks;
        }

    }
}
