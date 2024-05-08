using Lesson.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.UseCases.Lessons.Queries
{
    public class GetAllLessonsQuery : IRequest<List<LessonModel>>
    {

    }
}
