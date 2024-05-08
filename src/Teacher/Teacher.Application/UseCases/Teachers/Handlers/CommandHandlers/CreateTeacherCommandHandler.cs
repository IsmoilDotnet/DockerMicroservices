using MediatR;
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
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ResponseModel>
    {
        private readonly ITeacherDbContext _context;

        public CreateTeacherCommandHandler(ITeacherDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var teacher = new TeacherModel
                {
                    Name = request.Name,
                    age = request.age,
                    Email = request.Email,
                    Password = request.Password,
                };

                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Succesfully Created!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Error The Teacher isn't Created!",
                StatusCode = 400
            };
        }
    }
}
