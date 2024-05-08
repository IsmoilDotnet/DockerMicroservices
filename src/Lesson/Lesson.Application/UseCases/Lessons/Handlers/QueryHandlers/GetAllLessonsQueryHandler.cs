using Lesson.Application.Abstractions;
using Lesson.Application.UseCases.Lessons.Queries;
using Lesson.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Application.UseCases.Lessons.Handlers.QueryHandlers
{
    public class GetAllLessonsQueryHandler : IRequestHandler<GetAllLessonsQuery, List<LessonModel>>
    {
        private readonly ILessonDbContext _context;

        public GetAllLessonsQueryHandler(ILessonDbContext context)
        {
            _context = context;
        }

        public async Task<List<LessonModel>> Handle(GetAllLessonsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Lessons.ToListAsync(cancellationToken);
        }
    }
}
