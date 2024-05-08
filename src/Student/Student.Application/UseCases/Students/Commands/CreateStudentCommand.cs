using MediatR;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.UseCases.Students.Commands
{
    public class CreateStudentCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
