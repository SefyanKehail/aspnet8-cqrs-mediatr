using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features.Product.DTOs;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }


        public async Task<ProductDTO> CreateAsync(RequestProductDTO requestProductDTO)
        {

            // can be null because the RequestProductDTO is also used for patching so some props can be null, I supress it here with "!"
            var product = new Product
            {
                Name = requestProductDTO.Name!,
                Amount = (decimal)requestProductDTO.Amount!
            };

            product = await _productRepository.CreateAsync(product);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount
            };

        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            await _productRepository.DeleteAsync(product);
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount
            };
        }

        private async Task<Product?> GetByIdAsyncFullEntity(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }


        public async Task<ProductDTO> UpdateAsync(int id, RequestProductDTO requestProductDTO)
        {
            var product = await GetByIdAsyncFullEntity(id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            product.Name = requestProductDTO.Name != null ? requestProductDTO.Name : product.Name;
            product.Amount = requestProductDTO.Amount != null ? (decimal)requestProductDTO.Amount : product.Amount;


            await _productRepository.UpdateAsync(id, product);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount
            };
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductDTO { Id = p.Id, Name = p.Name, Amount = p.Amount });
        }
    }
}