using Admin.Application.Abstractions;
using Admin.Application.UseCases.Admins.Commands;
using Admin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.UseCases.Admins.Handlers.CommandHandlers
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, ResponseModel>
    {
        private readonly IAdminDbContext _context;

        public CreateAdminCommandHandler(IAdminDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var admin = new AdminModel
                {
                    UserName = request.UserName,
                    age = request.age,
                    Email = request.Email,
                    Password = request.Password,
                };

                await _context.Admins.AddAsync(admin);
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
