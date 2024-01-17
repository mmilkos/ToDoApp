using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure.Seeders
{
    public class TodoApiSeeder
    {
        private readonly ToDoAppDbContext _dbContext;
        public TodoApiSeeder(ToDoAppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task SeedAsync() 
        {
            bool isConected = await _dbContext.Database.CanConnectAsync();
            bool anyTasks = _dbContext.Tasks.Any();

            if (isConected) 
            {
                if (!anyTasks) 
                {
                    var firstTask = new Domain.Entities.UserTask();
                    firstTask.Name = "Create to do app";
                    firstTask.Description = "First task";

                    _dbContext.Tasks.Add(firstTask);
                    await _dbContext.SaveChangesAsync();
                }
            }

        }
    }
}
