using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features.Product.DTOs;
using api.Features.Product.Querries;
using api.Services;
using MediatR;

namespace api.Features.Product.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO?>
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDTO?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id < 0)
            {
                throw new InvalidProductIdException();
            }
            return await _productService.GetByIdAsync(request.Id);
        }
    }
}