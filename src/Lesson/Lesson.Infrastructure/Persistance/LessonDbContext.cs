using Lesson.Application.Abstractions;
using Lesson.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Infrastructure.Persistance
{
    public class LessonDbContext : DbContext, ILessonDbContext
    {
        public LessonDbContext(DbContextOptions<LessonDbContext> options) 
            : base(options) 
        {

        }

        public DbSet<LessonModel> Lessons { get; set; }
    }
}
