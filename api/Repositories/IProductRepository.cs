using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using api.Models;

namespace api.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product Product);
        Task DeleteAsync(Product product);
        Task<Product> UpdateAsync(int id, Product Product);
        Task<IEnumerable<Product>> GetAllAsync();
        IQueryable<Product> GetAllQuery();
    }
}