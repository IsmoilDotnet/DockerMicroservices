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
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, ResponseModel>
    {
        private readonly ITeacherDbContext _context;

        public UpdateTeacherCommandHandler(ITeacherDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (teacher != null)
            {
                teacher.Name = request.Name;
                teacher.age = request.age;
                teacher.Email = request.Email;
                teacher.Password = request.Password;

                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = " Succesfully Updated!",
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
