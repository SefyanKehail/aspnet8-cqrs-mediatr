using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using api.Models;

namespace api.Mappers
{
    public class ProductMapper
    {
        public static ProductDTO ToDto(Product product){
            return new ProductDTO {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount
            };
        }

        public static Product ToEntity(ProductDTO productDTO){
            return new Product {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Amount = productDTO.Amount
            };
        }
    }
}