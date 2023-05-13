using BoardingTracker.Application.Infrastructure;
using FluentValidation;
using System.Text.Json;

namespace BoardingTracker.WebApi.Infrastructure.ExceptionHandling.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public GlobalExceptionHandlingMiddleware(
            RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger, IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var responseObj = HandleException(ex, out var statusCode);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                await context.Response.Body.WriteAsync(
                    JsonSerializer.SerializeToUtf8Bytes(
                        responseObj, new JsonSerializerOptions { IgnoreNullValues = true }));
            }
        }

        private ExceptionModel HandleException(Exception ex, out int statusCode)
        {
            var errorResponse = new ExceptionModel
            {
                Message = ex.Message
            };

            if (_environment.IsDevelopment())
            {
                errorResponse.StackTrace = ex.StackTrace;
            }

            statusCode = StatusCodes.Status500InternalServerError;

            if (ex is NotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
            }

            if (ex is ValidationException)
            {
                statusCode = StatusCodes.Status400BadRequest;
            }

            return errorResponse;
        }
    }
}
