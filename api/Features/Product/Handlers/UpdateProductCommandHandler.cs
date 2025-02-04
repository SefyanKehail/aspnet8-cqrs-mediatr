using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features.Product.Commands;
using api.Features.Product.DTOs;
using api.Repositories;
using api.Services;
using MediatR;

namespace api.Features.Product.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        // TODO refactor to return productDTO
        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 0)
            {
                throw new InvalidProductIdException();
            }

            if (request.requestProductDTO == null)
            {
                throw new ProductNotFoundException();
            }
            
            return await _productService.UpdateAsync(request.Id, request.requestProductDTO);
        }
    }
}