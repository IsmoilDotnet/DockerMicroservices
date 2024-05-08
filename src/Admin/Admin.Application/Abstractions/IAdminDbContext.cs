using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.Abstractions
{
    public interface IAdminDbContext
    {
        public DbSet<AdminModel> Admins { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
