using Microsoft.EntityFrameworkCore;
using Student.Application.Abstractions;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure.Persistance
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) 
            : base(options)
        {

        }

        public DbSet<StudentModel> Students { get; set; }
    }
}
