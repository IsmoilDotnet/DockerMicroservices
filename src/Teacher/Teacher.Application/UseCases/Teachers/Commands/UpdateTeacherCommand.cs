using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Domain.Entities;

namespace Teacher.Application.UseCases.Teachers.Commands
{
    public class UpdateTeacherCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
