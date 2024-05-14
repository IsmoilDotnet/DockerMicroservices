using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Application.Abstractions;
using Product.Application.UseCases.ProductCases.Queries;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductModel>>
    {
        private readonly IProductDbContext _context;

        public GetAllProductsQueryHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
