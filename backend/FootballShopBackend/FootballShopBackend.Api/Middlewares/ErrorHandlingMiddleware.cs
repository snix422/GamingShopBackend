using FootballShopBackend.Application.Exceptions;
using System.Net;
using System.Text.Json;
using FluentValidation;

namespace FootballShopBackend.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }

        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;
            var result = string.Empty;

            switch(exception)
            {
                case ValidationException validationException:
                    code = StatusCodes.Status400BadRequest;
                    result = JsonSerializer.Serialize(new { error = "Validation error", details = validationException.Errors.Select(e => e.ErrorMessage) });
                    break;
                case NotFoundException notFoundException:
                    code = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new { error = notFoundException.Message });
                    break;
                case BadRequestException badRequestException:
                    code = (int)HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { error = badRequestException.Message });
                    break;
                case Exception e:
                    _logger.LogError(e, "Something went wrong");
                    result = JsonSerializer.Serialize(new { error = "An unexpected error occurred." });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
        
    }
}
