using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant.OrderService.Infrastructure.Exceptions;
using Restaurant.OrderService.Infrastructure.Middleware.ActionResults;

namespace Restaurant.OrderService.Infrastructure.Middleware.Filters
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode;

            if (context.Exception is ObjectAlreadyExistsException)
            {
                statusCode = StatusCodes.Status409Conflict;
                ValidationProblemDetails problemDetails = ParseError(context, statusCode);
                context.Result = new ConflictErrorObjectResult(problemDetails);
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;
                ValidationProblemDetails problemDetails = ParseError(context, statusCode);
                context.Result = new InternalServerErrorObjectResult(problemDetails);
            }

            context.HttpContext.Response.StatusCode = statusCode;
            context.ExceptionHandled = true;
        }

        private static ValidationProblemDetails ParseError(ExceptionContext context, int statusCode)
        {
            return new ValidationProblemDetails
            {
                Instance = context.HttpContext.Request.Method,
                Status = statusCode,
                Detail = context.Exception.Message,
                Type = context.GetType().ToString()
            };
        }
    }
}
