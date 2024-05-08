using Lesson.Application.Abstractions;
using Lesson.Application.UseCases.Lessons.Commands;
using Lesson.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.UseCases.Lessons.Handlers.CommandHandlers
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, ResponseModel>
    {
        private readonly ILessonDbContext _context;

        public CreateLessonCommandHandler(ILessonDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var lesson = new LessonModel
                {
                    LessonName = request.LessonName,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    LastLessonDate = request.LastLessonDate,
                    FirstLessonDate = request.FirstLessonDate,
                };

                await _context.Lessons.AddAsync(lesson);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Succesfully Created!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Not Created!",
                StatusCode = 400
            };
        }
    }
}
