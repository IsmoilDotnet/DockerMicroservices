using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Domain.Entities;

namespace Teacher.Application.Abstractions
{
    public interface ITeacherDbContext
    {
        public DbSet<TeacherModel> Teachers { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
