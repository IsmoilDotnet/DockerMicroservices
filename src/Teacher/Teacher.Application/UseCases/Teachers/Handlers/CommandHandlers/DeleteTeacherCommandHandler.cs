using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Application.Abstractions;
using Teacher.Application.UseCases.Teachers.Commands;
using Teacher.Domain.Entities;

namespace Teacher.Application.UseCases.Teachers.Handlers.CommandHandlers
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, ResponseModel>
    {
        private readonly ITeacherDbContext _context;

        public DeleteTeacherCommandHandler(ITeacherDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id  == request.Id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Succesfully deleted!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Teacher not found!",
                StatusCode = 404
            };
        }
    }
}
