using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features.Product.DTOs;
using MediatR;

namespace api.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {

    }
}