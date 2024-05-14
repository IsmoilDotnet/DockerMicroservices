using MediatR;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.ProductCases.Commands
{
    public class CreateProductCommand : IRequest<ResponseModel>
    {
        public string ProductName { get; set; } = "";
        public string ProductDescription { get; set; } = "";
        public bool IsItOnSale { get; set; } = false;
    }
}
