using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;

namespace api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidArgumentException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync("Invalid resource id");
            }
            catch (ProductNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync("Resource not found");
            }
            catch (RequestProductDTONullException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync("Invalid request");
            }
            // catch (Exception e)
            // {
            //     context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //     await context.Response.WriteAsJsonAsync("An Unexpected error occured");
            //     await context.Response.WriteAsJsonAsync(e.Message);

            // }
            // catch exceptions
        }
    }
}