using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Application.Abstractions;
using Teacher.Infrastructure.Persistance;

namespace Teacher.Infrastructure
{
    public static class TeacherInfrastructureDependencyInjection
    {
        public static IServiceCollection AddTeacherInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ITeacherDbContext, TeacherDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("TeacherConnectionString"));
            });

            return services;
        }
    }
}
