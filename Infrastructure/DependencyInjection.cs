using Application.Interface;
using Domain.Entities;
using Infrastructure.DataBase;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                
            });
            
            services.AddScoped<IServiceRepository, ServiceRepository>();
            return services;

        }
    }
}
