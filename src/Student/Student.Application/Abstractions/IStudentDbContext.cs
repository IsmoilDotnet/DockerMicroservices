using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Abstractions
{
    public interface IStudentDbContext
    {
        public DbSet<StudentModel> Students {  get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
