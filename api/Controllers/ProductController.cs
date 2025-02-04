using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Features.Product.Commands;
using api.Features.Product.DTOs;
using api.Features.Product.Queries;
using api.Features.Product.Querries;
using api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    /// <summary>
    /// Controller responsible for managing products in the system.
    /// Provides endpoints for creating, updating, deleting, and retrieving products.
    /// </summary>
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves a product by its unique identifier (ID).
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>
        /// A 200 OK response containing the product data if the product is found, or
        /// a 404 Not Found response if no product is found with the given ID.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var productDTO = await _mediator.Send(query);

            if (productDTO == null)
            {
                return NotFound();
            }

            return Ok(productDTO);

        }

        /// <summary>
        /// Creates a new product in the system.
        /// </summary>
        /// <param name="requestProductDTO">The data transfer object (DTO) containing the product information to be created.</param>
        /// <returns>A 200 OK response containing the created product data if the creation is successful, or a 400 Bad Request if the request is invalid.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestProductDTO requestProductDTO)
        {
            var createProductCommand = new CreateProductCommand(requestProductDTO);

            var productDTO = await _mediator.Send(createProductCommand);

            // TODO refactor this to resource header
            return Ok(productDTO);
        }

        /// <summary>
        /// Deletes a product by its unique identifier (ID).
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>
        /// A 204 No Content response if the product is successfully deleted, or
        /// a 400 Bad Request response if the product was not found and could not be deleted.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteProductCommand = new DeleteProductCommand(id);

            await _mediator.Send(deleteProductCommand);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing product by its unique identifier (ID).
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="requestProductDTO">The data transfer object (DTO) containing the updated product information.</param>
        /// <returns>
        /// A 200 OK response containing the updated product data if the update is successful, or
        /// a 400 Bad Request response if the product was not found or the update fails.
        /// </returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestProductDTO requestProductDTO)
        {
            var updateProductCommand = new UpdateProductCommand(id, requestProductDTO);

            ProductDTO productDTO = await _mediator.Send(updateProductCommand);

            return Ok(productDTO);
        }

        /// <summary>
        /// Retrieves a list of all products.
        /// </summary>
        /// <returns>
        /// A 200 OK response containing a list of all products.
        /// </returns>
        [HttpGet("/products")]
        public async Task<IActionResult> GetAll()
        {
            var getAllProductsQuery = new GetAllProductsQuery();
            
            var productDTOs = await _mediator.Send(getAllProductsQuery);

            return Ok(productDTOs);
        }
    }
}