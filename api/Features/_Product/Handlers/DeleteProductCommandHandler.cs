using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features._Product.Commands;
using api.Repositories;
using api.Services;
using MediatR;

namespace api.Features._Product.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 0)
            {
                throw new InvalidProductIdException();
            }

            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            await _productRepository.DeleteAsync(product);
        }
    }
}