using MediatR;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.ProductCases.Commands
{
    public class DeleteProductCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
