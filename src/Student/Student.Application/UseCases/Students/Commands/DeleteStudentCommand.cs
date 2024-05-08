using MediatR;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.UseCases.Students.Commands
{
    public class DeleteStudentCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
