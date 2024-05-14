using MediatR;
using Product.Application.Abstractions;
using Product.Application.UseCases.ProductCases.Commands;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.ProductCases.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseModel>
    {
        private readonly IProductDbContext _context;

        public CreateProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var product = new ProductModel
                {
                    ProductName = request.ProductName,
                    ProductDescription = request.ProductDescription,
                    IsItOnSale = request.IsItOnSale,
                };

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Created!"
                };
            }

            return new ResponseModel
            {
                Message = "Not Created!"
            };
        }
    }
}
