using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Application.Abstractions;
using Teacher.Domain.Entities;

namespace Teacher.Infrastructure.Persistance
{
    public class TeacherDbContext : DbContext, ITeacherDbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) 
            : base(options) 
        {

        }

        public DbSet<TeacherModel> Teachers { get; set; }
    }
}
