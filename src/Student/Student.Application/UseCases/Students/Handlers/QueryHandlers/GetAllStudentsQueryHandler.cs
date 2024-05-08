using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Application.Abstractions;
using Student.Application.UseCases.Students.Queries;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.UseCases.Students.Handlers.QueryHandlers
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentModel>>
    {
        private readonly IStudentDbContext _context;

        public GetAllStudentsQueryHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.ToListAsync(cancellationToken);
        }

    }
}
