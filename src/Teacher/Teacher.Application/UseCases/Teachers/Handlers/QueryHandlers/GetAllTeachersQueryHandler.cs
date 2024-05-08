using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Application.Abstractions;
using Teacher.Application.UseCases.Teachers.Queries;
using Teacher.Domain.Entities;

namespace Teacher.Application.UseCases.Teachers.Handlers.QueryHandlers
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherModel>>
    {
        private readonly ITeacherDbContext _context;

        public GetAllTeachersQueryHandler(ITeacherDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherModel>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Teachers.ToListAsync(cancellationToken);
        }
    }
}
