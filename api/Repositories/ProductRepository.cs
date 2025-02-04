using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Exceptions;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            
            return product; 
        }

        public async Task DeleteAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(int id, Product product)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}