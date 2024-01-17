using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Aplication.Mappings;
using TodoApi.Aplication.Services;


namespace TodoApi.Aplication.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddAplication(this IServiceCollection service, IConfiguration configuration) 
        {
            var authentication = configuration.GetSection("Authentication");
            string JwtIssuer = authentication.GetValue<string>("JwtIssuer");
            string JwtKey = authentication.GetValue<string>("JwtKey");

            service.AddScoped<ITasksService, TasksService>();
            service.AddScoped<IUsersService, UsersService>();
            service.AddAutoMapper(typeof(UserTaskMappingProfile));
            service.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg => 
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = JwtIssuer, //wydawca tokenu
                    ValidAudience = JwtIssuer, //jakie podmioty mogą używać tokenu
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey)) //klucz prywatny
                };
            });   
        }
    }
}
