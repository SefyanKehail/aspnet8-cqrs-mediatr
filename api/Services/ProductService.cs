// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using api.Exceptions;
// using api.Features.Product.DTOs;
// using api.Mappers;
// using api.Models;
// using api.Repositories;

// namespace api.Services
// {
//     public class ProductService : IProductService
//     {
//         private readonly IProductRepository _productRepository;

//         public ProductService(IProductRepository productRepository)
//         {
//             _productRepository = productRepository;
//         }


//         public async Task<ProductDTO> CreateAsync(RequestProductDTO requestProductDTO)
//         {

//             // can be null because the RequestProductDTO is also used for patching so some props can be null, I supress it here with "!"
//             var product = new Product
//             {
//                 Name = requestProductDTO.Name!,
//                 Amount = (decimal)requestProductDTO.Amount!
//             };  

//             product = await _productRepository.CreateAsync(product);

//             return ProductMapper.ToDto(product);

//         }

//         public async Task DeleteAsync(int id)
//         {
//             var product = await _productRepository.GetByIdAsync(id);

//             if (product == null)
//             {
//                 throw new ProductNotFoundException();
//             }

//             await _productRepository.DeleteAsync(product);
//         }

//         public async Task<ProductDTO?> GetByIdAsync(int id)
//         {
//             var product = await _productRepository.GetByIdAsync(id);

//             if (product == null)
//             {
//                 return null;
//             }

//             return ProductMapper.ToDto(product);
//         }


//         public async Task<ProductDTO> UpdateAsync(int id, RequestProductDTO requestProductDTO)
//         {
//             var product = await GetByIdAsync(id);

//             if (product == null)
//             {
//                 throw new ProductNotFoundException();
//             }

            
//             product.Name = requestProductDTO.Name != null ? requestProductDTO.Name : product.Name;
//             product.Amount = requestProductDTO.Amount != null ? (decimal)requestProductDTO.Amount : product.Amount;
            
//             await _productRepository.UpdateAsync(id, ProductMapper.ToEntity(product));
        
            
//             return product;
//         }

//         public async Task<IEnumerable<ProductDTO>> GetAllAsync()
//         {
//             var products = await _productRepository.GetAllAsync();

//             return products.Select(ProductMapper.ToDto);
//         }

//         public IQueryable<Product> GetAllQuery()
//         {
//             return _productRepository.GetAllQuery();
//         }
//     }
// }