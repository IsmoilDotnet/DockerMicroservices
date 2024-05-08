using Admin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.UseCases.Admins.Commands
{
    public class UpdateAdminCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
