using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using api.Features._Product.Queries;
using api.Mappers;
using api.Models;
using api.Repositories;
using api.Services;
using MediatR;

namespace api.Features._Product.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
           IEnumerable<Product> products =  await _productRepository.GetAllAsync();

           return products.Select(ProductMapper.ToDto);
        }
    }
}