using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features._Product.Commands;
using api.Features._Product.DTOs;
using api.Features._Product.Handlers;
using api.Features._Product.Queries;
using api.Features._Product.Querries;
using api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);
         
            var productDTO = await _mediator.Send(query);

            return Ok(productDTO);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var productDTO = await _mediator.Send(createProductCommand);

            // TODO refactor this to resource header
            return Ok(productDTO);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteProductCommand = new DeleteProductCommand(id);

            await _mediator.Send(deleteProductCommand);

            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestProductDTO requestProductDTO)
        {
            var updateProductCommand = new UpdateProductCommand(id, requestProductDTO);

            ProductDTO productDTO = await _mediator.Send(updateProductCommand);

            return Ok(productDTO);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var getAllProductsQuery = new GetAllProductsQuery();

            var productDTOs = await _mediator.Send(getAllProductsQuery);

            return Ok(productDTOs);
        }

        [HttpGet("all/paged")]
        public async Task<IActionResult> GetAllPaginated([FromQuery] ProductQueryParamsDTO productQueryParamsDTO)
        {
            var getProductsPaginatedQuery = new GetProductsPaginatedQuery(productQueryParamsDTO);
            var productDTOsPaginated = await _mediator.Send(getProductsPaginatedQuery);
            return Ok(productDTOsPaginated);
        }
    }
}