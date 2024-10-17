using Application.Repositories.Interfaces;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class DependecyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IFormRepository, FormRepository>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Environment.GetEnvironmentVariable("DefaultConnection") ?? configuration.GetConnectionString("DefaultConnection"))
            );
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IFormInstanceService, FormInstanceService>();
        }

        public static void AddUseCases(this IServiceCollection services)
        { 
        }

        public static void ConfigPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            
        }
    }
}
