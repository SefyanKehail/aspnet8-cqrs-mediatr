using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features.Product.DTOs;

namespace api.Services
{
    public interface IProductService
    {
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<ProductDTO> CreateAsync(RequestProductDTO requestProductDTO);
        Task DeleteAsync(int id);
        Task<ProductDTO> UpdateAsync(int id, RequestProductDTO requestProductDTO);
        Task<IEnumerable<ProductDTO>> GetAllAsync();
    }
}