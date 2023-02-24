using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace General.CrossCutting.Lib
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public class ErrorHandlerMiddleware
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
        private readonly RequestDelegate _next;

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public ErrorHandlerMiddleware(RequestDelegate next)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            _next = next;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task Invoke(HttpContext context)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    AppException e => (int)HttpStatusCode.BadRequest,// custom application error
                    KeyNotFoundException e => (int)HttpStatusCode.NotFound,// not found error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };
                var result = JsonSerializer.Serialize(new { message = error?.ToString() });
                await response.WriteAsync(result);
            }
        }
    }
}