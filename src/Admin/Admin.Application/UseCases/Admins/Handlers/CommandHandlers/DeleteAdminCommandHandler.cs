using Admin.Application.Abstractions;
using Admin.Application.UseCases.Admins.Commands;
using Admin.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.UseCases.Admins.Handlers.CommandHandlers
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, ResponseModel>
    {
        private readonly IAdminDbContext _context;

        public DeleteAdminCommandHandler(IAdminDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (admin != null)
            {

                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Succesfully Deleted!",
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
