using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Application.Abstractions;
using Student.Application.UseCases.Students.Commands;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.UseCases.Students.Handlers.CommandHandlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ResponseModel>
    {
        private readonly IStudentDbContext _context;

        public DeleteStudentCommandHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id  == request.Id);

            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Succesfully deleted!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Student Not Found!",
                StatusCode = 400
            };
        }
    }
}
