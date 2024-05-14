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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseModel>
    {
        private readonly IProductDbContext _context;

        public DeleteProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product != null)
            {
                 _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel { 
                    Message = "Deleted!"
                };
            }

            return new ResponseModel
            {
                Message = "Product Not Found!"
            };
        }
    }
}
