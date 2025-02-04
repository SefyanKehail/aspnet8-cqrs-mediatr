using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features.Product.Commands;
using api.Services;
using MediatR;

namespace api.Features.Product.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 0) {
                throw new InvalidProductIdException();
            }
            
            await _productService.DeleteAsync(request.Id);
        }
    }
}