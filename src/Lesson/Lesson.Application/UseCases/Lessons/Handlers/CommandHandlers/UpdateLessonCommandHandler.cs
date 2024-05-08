using Lesson.Application.Abstractions;
using Lesson.Application.UseCases.Lessons.Commands;
using Lesson.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.UseCases.Lessons.Handlers.CommandHandlers
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, ResponseModel>
    {
        private readonly ILessonDbContext _context;

        public UpdateLessonCommandHandler(ILessonDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id  == request.Id);

            if (lesson != null)
            {
                lesson.LessonName = request.LessonName;
                lesson.StartTime = request.StartTime;
                lesson.EndTime = request.EndTime;
                lesson.LastLessonDate = request.LastLessonDate;
                lesson.FirstLessonDate = request.FirstLessonDate;

                _context.Lessons.Update(lesson);
                await _context.SaveChangesAsync(cancellationToken);


                return new ResponseModel
                {
                    Message = "Succesfully Updated!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Lesson Not Found!",
                StatusCode = 400
            };
        }
    }
}
