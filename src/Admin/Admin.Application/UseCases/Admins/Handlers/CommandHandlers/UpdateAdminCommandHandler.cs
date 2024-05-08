using Admin.Application.Abstractions;
using Admin.Application.UseCases.Admins.Commands;
using Admin.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.UseCases.Admins.Handlers.CommandHandlers
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, ResponseModel>
    {
        private readonly IAdminDbContext _context;

        public UpdateAdminCommandHandler(IAdminDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Id  == request.Id);

            if (admin != null)
            {
                admin.UserName = request.UserName;
                admin.age = request.age;
                admin.Email = request.Email;
                admin.Password = request.Password;

                _context.Admins.Update(admin);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Succesfully Updated!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Admin Not Found!",
                StatusCode = 400
            };
        }
    }
}
