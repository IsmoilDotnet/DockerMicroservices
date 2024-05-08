using Admin.Application.Abstractions;
using Admin.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Infrastructure
{
    public static class AdminInfrastructureDependencyInjection
    {
        public static IServiceCollection AddAdminInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAdminDbContext, AdminDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("AdminConnectionString"));
            });

            return services;
        }
    }
}
