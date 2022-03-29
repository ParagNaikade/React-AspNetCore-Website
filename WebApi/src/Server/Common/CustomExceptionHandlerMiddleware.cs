using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Server.Common
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(ILogger<CustomExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = ex.Message;

            _logger.LogError(ex, $"An error occurred processing the request: {result}");

            return context.Response.WriteAsync(result);
        }
    }
}
