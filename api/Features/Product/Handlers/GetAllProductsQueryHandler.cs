using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features.Product.DTOs;
using api.Features.Product.Queries;
using api.Services;
using MediatR;

namespace api.Features.Product.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductService _productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
           return await _productService.GetAllAsync();
        }
    }
}