using Metflix.Domain.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Metflix.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // TODO: Null is coming, find out why.
                // var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    ConflictException => StatusCodes.Status409Conflict,
                    _ => StatusCodes.Status500InternalServerError
                };

                // TODO: Search how I get the Code property created in exception classes.
                await context.Response.WriteAsync(JsonSerializer.Serialize(new 
                {
                    StatusCode = context.Response.StatusCode,
                    Messages = ex.Message
                }));
            }
        }
    }
}
