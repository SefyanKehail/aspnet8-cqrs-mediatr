using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace api.Features._Product.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}