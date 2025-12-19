using System.Net;
using System.Text.Json;
using HealthTracker.API.Models;
using HealthTracker.Application.Exceptions;

namespace HealthTracker.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var problemDetails = new CustomProblemDetails
            {
                Title = "An error occurred",
                Detail = ex.Message,
                Status = (int)HttpStatusCode.InternalServerError,
            };

            if (ex is BadRequestException badRequestEx)
            {
                problemDetails.Title = "Validation Failed";
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                problemDetails.Errors = badRequestEx.ValidationErrors;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = problemDetails.Status.Value;

            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }
    }
}
