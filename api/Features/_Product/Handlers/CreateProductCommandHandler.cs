using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features._Product.Commands;
using api.Features._Product.DTOs;
using api.Mappers;
using api.Models;
using api.Repositories;
using api.Services;
using MediatR;

namespace api.Features._Product.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {            
            if (request.requestProductDTO == null){
                throw new RequestProductDTONullException();
            }

           // RequestProductDTO is also used for patching so some props can be null, I supress it here with "!"
            var product = new Product
            {
                Name = request.requestProductDTO.Name!,
                Amount = (decimal)request.requestProductDTO.Amount!
            };

            return ProductMapper.ToDto(await _productRepository.CreateAsync(product));
        }
    }
}