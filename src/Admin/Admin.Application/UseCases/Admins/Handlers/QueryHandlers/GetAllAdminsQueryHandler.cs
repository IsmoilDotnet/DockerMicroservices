using Admin.Application.Abstractions;
using Admin.Application.UseCases.Admins.Queries;
using Admin.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.UseCases.Admins.Handlers.QueryHandlers
{
    public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, List<AdminModel>>
    {
        private readonly IAdminDbContext _context;

        public GetAllAdminsQueryHandler(IAdminDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdminModel>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Admins.ToListAsync(cancellationToken);
        }
    }
}
