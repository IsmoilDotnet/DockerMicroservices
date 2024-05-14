using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Abstractions
{
    public interface IProductDbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
