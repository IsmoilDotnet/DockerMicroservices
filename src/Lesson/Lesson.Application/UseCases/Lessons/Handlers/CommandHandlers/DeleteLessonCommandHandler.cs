using Lesson.Application.Abstractions;
using Lesson.Application.UseCases.Lessons.Commands;
using Lesson.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.UseCases.Lessons.Handlers.CommandHandlers
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, ResponseModel>
    {
        private readonly ILessonDbContext _context;

        public DeleteLessonCommandHandler(ILessonDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id  == request.Id);

            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Succesfully Deleted!",
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
