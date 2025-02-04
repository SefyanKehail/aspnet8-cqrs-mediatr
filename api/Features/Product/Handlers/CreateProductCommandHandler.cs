using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features.Product.Commands;
using api.Features.Product.DTOs;
using api.Services;
using MediatR;

namespace api.Features.Product.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {            
            if (request.requestProductDTO == null){
                throw new RequestProductDTONullException();
            }
            return await _productService.CreateAsync(request.requestProductDTO);
        }
    }
}