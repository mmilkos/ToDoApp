using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;
using TodoApi.Infrastructure.Repositories;
using TodoApi.Infrastructure.Seeders;

namespace TodoApi.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var conectionString = configuration.GetConnectionString("ToDoApp");
            services.AddDbContext<ToDoAppDbContext>(options => options.UseSqlServer(conectionString));
            services.AddScoped<TodoApiSeeder>();
            services.AddScoped<ITodoApiRepository, TodoApiRepository>();
        }
    }
}
