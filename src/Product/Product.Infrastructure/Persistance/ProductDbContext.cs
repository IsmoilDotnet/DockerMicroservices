using Microsoft.EntityFrameworkCore;
using Product.Application.Abstractions;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistance
{
    public class ProductDbContext : DbContext, IProductDbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) 
        {

        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
