using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features.Product.DTOs;
using api.Mappers;
using api.Models;
using api.Services;
using api.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Features.Product.Handlers
{
    public class GetProductsPaginatedQueryHandler : IRequestHandler<GetProductsPaginatedQuery, PagedResult<ProductDTO>>
    {
        private readonly IProductService _productService;

        public GetProductsPaginatedQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<PagedResult<ProductDTO>> Handle(GetProductsPaginatedQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Models.Product> products = _productService.GetAllQuery();

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
                                ? DynamicSorting<Models.Product>.SortByDescending(products, queryParamsDTO.SortBy)
                                : DynamicSorting<Models.Product>.SortyBy(products, queryParamsDTO.SortBy);
            }


            // Pagination (count items , get items,  skip, take, page size, page number, )
            // I don't know what's wrong here with Queryable
            int totalItems = await products.CountAsync();

            List<ProductDTO> productDTOs = products
                            .Skip((queryParamsDTO.PageNumber - 1) * queryParamsDTO.PageSize)
                            .Take(queryParamsDTO.PageSize)
                            .Select(ProductMapper.ToDto).ToList();

            return new PagedResult<ProductDTO>(productDTOs, totalItems, queryParamsDTO.PageSize, queryParamsDTO.PageNumber);
        }
    }
}