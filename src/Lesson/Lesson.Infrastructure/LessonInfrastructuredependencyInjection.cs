using Lesson.Application.Abstractions;
using Lesson.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Infrastructure
{
    public static class LessonInfrastructuredependencyInjection
    {
        public static IServiceCollection AddLessonInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ILessonDbContext, LessonDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LessonConnectionString"));
            });

            return services;
        }
    }
}
