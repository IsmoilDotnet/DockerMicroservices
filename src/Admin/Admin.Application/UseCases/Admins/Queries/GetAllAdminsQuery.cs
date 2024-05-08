using Admin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.UseCases.Admins.Queries
{
    public class GetAllAdminsQuery : IRequest<List<AdminModel>>
    {

    }
}
