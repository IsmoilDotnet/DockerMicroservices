using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Application.Abstractions;
using Student.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure
{
    public static class StudentInfrastructureDependencyInjection
    {
        public static IServiceCollection AddStudentInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IStudentDbContext, StudentDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("StudentConnectionString"));
            });

            return services;
        }
    }
}
