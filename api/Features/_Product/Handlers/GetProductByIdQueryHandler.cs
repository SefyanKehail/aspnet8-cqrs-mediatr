using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features._Product.DTOs;
using api.Features._Product.Querries;
using api.Mappers;
using api.Models;
using api.Repositories;
using api.Services;
using MediatR;

namespace api.Features._Product.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO?>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id < 0)
            {
                throw new InvalidArgumentException();
            }

            Product? product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            return ProductMapper.ToDto(product);
        }
    }
}