using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application;
using Product.Application.Abstractions;
using Product.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public static class ProductInfrastructureDI
    {
        public static IServiceCollection AddProductInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<IProductDbContext, ProductDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ProductConnectionString"));
            });

            return services;
        }
    }
}
