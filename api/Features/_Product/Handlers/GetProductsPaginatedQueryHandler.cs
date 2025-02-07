using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using api.Mappers;
using api.Models;
using api.Repositories;
using api.Services;
using api.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Features._Product.Handlers
{
    public class GetProductsPaginatedQueryHandler : IRequestHandler<GetProductsPaginatedQuery, PagedResult<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        private readonly ProductMapper _productMapper;

        public GetProductsPaginatedQueryHandler(IProductRepository productRepository, ProductMapper productMapper)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
        }

        public async Task<PagedResult<ProductDTO>> Handle(GetProductsPaginatedQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> products = _productRepository.GetAllQuery();

            ProductQueryParamsDTO queryParamsDTO = request.QueryParamsDTO;

            // Filtering ( testing against white spaces instead of empty string)

            if (!string.IsNullOrWhiteSpace(queryParamsDTO.Search))
            {
                products = products.Where(p => p.Name.Contains(queryParamsDTO.Search));
            }

            // Sorting 
            if (queryParamsDTO.SortBy != null)
            {
                products = queryParamsDTO.IsDescening
                                ? DynamicSorting<Product>.SortByDescending(products, queryParamsDTO.SortBy)
                                : DynamicSorting<Product>.SortyBy(products, queryParamsDTO.SortBy);
            }


            // Pagination (count items , get items,  skip, take, page size, page number, )
            // I don't know what's wrong here with Queryable
            int totalItems = await products.CountAsync();

            List<ProductDTO> productDTOs = products
                            .Skip((queryParamsDTO.PageNumber - 1) * queryParamsDTO.PageSize)
                            .Take(queryParamsDTO.PageSize)
                            .Select(_productMapper.ProductToProductDTO).ToList();

            return new PagedResult<ProductDTO>(productDTOs, totalItems, queryParamsDTO.PageSize, queryParamsDTO.PageNumber);
        }
    }
}