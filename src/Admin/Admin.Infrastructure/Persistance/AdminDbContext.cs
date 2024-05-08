using Admin.Application.Abstractions;
using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Infrastructure.Persistance
{
    public class AdminDbContext : DbContext, IAdminDbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) 
            : base(options) 
        {

        }

        public DbSet<AdminModel> Admins { get; set; }
    }
}
