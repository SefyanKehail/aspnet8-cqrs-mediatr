using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features._Product.DTOs;
using api.Models;
using api.Repositories;

namespace api.Mappers
{
    public class ProductMapper
    {
        private readonly IProductRepository _productRepository;

        public ProductMapper(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDTO ProductToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount,
                IsAvailableInStock = product.IsAvailableInStock
            };
        }

        public async Task<Product> ProductDTOToProduct(ProductDTO productDTO)
        {
            Product? retrievedFullProduct = await _productRepository.GetByIdAsync(productDTO.Id);

            if (retrievedFullProduct == null)
            {
                throw new ProductNotFoundException();
            }

            // in this cas the retrieved full product is the same as the Product we're returning here, but I'm just simulating if I'm mapping to another entity DTO
            return new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Amount = productDTO.Amount,
                IsAvailableInStock = productDTO.IsAvailableInStock,
                StockQuantity = retrievedFullProduct.StockQuantity,
                IsActive = retrievedFullProduct.IsActive
            };
        }

        public Product RequestProductDTOToProduct(RequestProductDTO requestProductDTO)
        {
            // RequestProductDTO is also used for patching so some props can be null, I supress it here with "!"
            var product = new Product
            {
                Name = requestProductDTO.Name!,
                Amount = (decimal)requestProductDTO.Amount!,
                StockQuantity = new Random().Next(1, 101),
            };

            return product;
        }
    }
}