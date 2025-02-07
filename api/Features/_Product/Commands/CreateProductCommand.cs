using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Features._Product.DTOs;
using MediatR;

namespace api.Features._Product.Commands
{
    // fix this to expect ProductDTO instead
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public RequestProductDTO requestProductDTO { get; set; }    
        public CreateProductCommand(RequestProductDTO requestProductDTO)
        {
            this.requestProductDTO = requestProductDTO;
        }


    }
}