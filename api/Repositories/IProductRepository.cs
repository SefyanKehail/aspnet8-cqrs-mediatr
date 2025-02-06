using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task DeleteAsync(Product product);
        Task UpdateAsync(int id, Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        IQueryable<Product> GetAllQuery();
    }
}