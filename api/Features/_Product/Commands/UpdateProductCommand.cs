using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using MediatR;

namespace api.Features._Product.Commands
{
    public class UpdateProductCommand : IRequest<ProductDTO>
    {

        public int Id { get; set; }
        public RequestProductDTO RequestProductDTO { get; set;}

        public UpdateProductCommand(int id, RequestProductDTO requestProductDTO)
        {
            Id = id;
            this.RequestProductDTO = requestProductDTO;
        }

    }
}