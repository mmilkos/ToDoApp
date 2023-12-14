using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Aplication.Services;

namespace TodoApi.Aplication.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddAplication(this IServiceCollection service) 
        {
            service.AddScoped<ITodoApiService, TodoApiService>();
        }
    }
}
