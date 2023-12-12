using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Infrastructure.Persistence
{
    public class ToDoAppDbContext : DbContext
    {
        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options) 
        {

        }

        //public DbSet<Domain>
        public DbSet<Domain.UserTask> Tasks { get; set; }
    }
}
