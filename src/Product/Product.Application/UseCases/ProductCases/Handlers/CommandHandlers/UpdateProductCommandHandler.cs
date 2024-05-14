using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResponseModel>
    {
        private readonly IProductDbContext _context;

        public UpdateProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product != null)
            {
                product.ProductName = request.ProductName;
                product.ProductDescription = request.ProductDescription;
                product.IsItOnSale = request.IsItOnSale;

                _context.Products.Update(product);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Updated!"
                };
            }

            return new ResponseModel
            {
                Message = "Product Not Found!"
            };
        }
    }
}
