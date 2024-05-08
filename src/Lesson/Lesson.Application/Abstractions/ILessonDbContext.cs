using Lesson.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.Abstractions
{
    public interface ILessonDbContext
    {
        public DbSet<LessonModel> Lessons { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
