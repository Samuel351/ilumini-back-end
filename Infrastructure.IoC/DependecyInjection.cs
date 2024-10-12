using Application.Repositories;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public static class DependecyInjection
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
                Environment.GetEnvironmentVariable("DefaultConnection") ?? configuration.GetConnectionString("DefaultConnection"))
            );
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
        }

        public static void AddUseCases(this IServiceCollection services)
        { 
        }
    }
}
