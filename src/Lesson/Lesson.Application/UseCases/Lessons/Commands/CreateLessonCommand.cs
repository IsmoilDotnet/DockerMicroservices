using Lesson.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.UseCases.Lessons.Commands
{
    public class CreateLessonCommand : IRequest<ResponseModel>
    {
        public string LessonName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string FirstLessonDate { get; set; }
        public string LastLessonDate { get; set; }
    }
}
