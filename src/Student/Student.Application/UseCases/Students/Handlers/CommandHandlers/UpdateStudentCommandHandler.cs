using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Application.Abstractions;
using Student.Application.UseCases.Students.Commands;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.UseCases.Students.Handlers.CommandHandlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ResponseModel>
    {
        private readonly IStudentDbContext _context;

        public UpdateStudentCommandHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id ==  request.Id);

            if (student != null)
            {
                student.Name = request.Name;
                student.age = request.age;
                student.Email = request.Email;
                student.Password = request.Password;

                _context.Students.Update(student);
                await _context.SaveChangesAsync(cancellationToken);


                return new ResponseModel
                {
                    Message = "Succesfully Updated!",
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
