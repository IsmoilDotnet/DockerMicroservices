using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Domain.Entities;

namespace Teacher.Application.UseCases.Teachers.Queries
{
    public class GetAllTeachersQuery : IRequest<List<TeacherModel>>
    {

    }
}
