using MediatR;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.ProductCases.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductModel>>
    {

    }
}
