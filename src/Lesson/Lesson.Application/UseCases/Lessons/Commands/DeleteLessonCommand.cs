using Lesson.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.UseCases.Lessons.Commands
{
    public class DeleteLessonCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
