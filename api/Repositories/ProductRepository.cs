using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Exceptions;
using api.Features._Product.DTOs;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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


        public IQueryable<Product> GetAllQuery()
        {
            return _dbContext.Products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateAsync(int id, Product product)
        {
            _dbContext.Update(product);

            await _dbContext.SaveChangesAsync();

            return product;
        }
    }
}