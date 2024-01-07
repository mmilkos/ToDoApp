using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Persistence
{
    public class ToDoAppDbContext : DbContext
    {
        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options) 
        {

        }

        //public DbSet<Domain>
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
