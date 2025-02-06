using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using MediatR;

namespace api.Features._Product.Querries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }

}