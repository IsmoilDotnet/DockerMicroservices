using MediatR;
using Student.Application.Abstractions;
using Student.Application.UseCases.Students.Commands;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.UseCases.Students.Handlers.CommandHandlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ResponseModel>
    {
        private readonly IStudentDbContext _context;

        public CreateStudentCommandHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var student = new StudentModel
                {
                    Name = request.Name,
                    age = request.age,
                    Email = request.Email,
                    Password = request.Password,
                };

                await _context.Students.AddAsync(student);
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
