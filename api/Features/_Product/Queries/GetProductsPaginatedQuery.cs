using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using api.Utils;
using MediatR;

namespace api.Features._Product.Handlers
{
    public class GetProductsPaginatedQuery : IRequest<PagedResult<ProductDTO>>
    {
        public ProductQueryParamsDTO QueryParamsDTO { get; set; }

        public GetProductsPaginatedQuery(ProductQueryParamsDTO queryParamsDTO)
        {
            this.QueryParamsDTO = queryParamsDTO;
        }
    }
}