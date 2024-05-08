using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Teacher.Domain.Entities;

namespace Teacher.Application.UseCases.Teachers.Commands
{
    public class CreateTeacherCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
