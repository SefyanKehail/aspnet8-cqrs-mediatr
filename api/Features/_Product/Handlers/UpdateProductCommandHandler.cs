using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features._Product.Commands;
using api.Features._Product.DTOs;
using api.Mappers;
using api.Repositories;
using api.Services;
using MediatR;

namespace api.Features._Product.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // TODO refactor to return productDTO
        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 0)
            {
                throw new InvalidArgumentException();
            }

            if (request.RequestProductDTO == null)
            {
                throw new InvalidArgumentException();
            }

            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            product.Name = request.RequestProductDTO.Name != null ? request.RequestProductDTO.Name : product.Name;
            product.Amount = request.RequestProductDTO.Amount != null ? (decimal)request.RequestProductDTO.Amount : product.Amount;

            product = await _productRepository.UpdateAsync(request.Id, product);

            return ProductMapper.ToDto(product);
        }
    }
}