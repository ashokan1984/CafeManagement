using CafeManagement.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace CafeManagement.WebAPI.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                    context.Response.ContentType = "application/json";

                    // Determine the response status code based on the exception type
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => (int)HttpStatusCode.NotFound,
                        BadRequestException => (int)HttpStatusCode.BadRequest,
                        AlreadyExistsException => (int)HttpStatusCode.BadRequest,
                        OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                        NoDataFoundException => (int)HttpStatusCode.NotFound,
                        ValidationException validationException => HandleValidationException(validationException, context),
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    // Prepare the error response
                    var errorResponse = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = contextFeature.Error is ValidationException
                            ? "Validation failed."
                            : contextFeature.Error.GetBaseException().Message
                    };

                    // Write the error response
                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });
        }

        private static int HandleValidationException(ValidationException validationException, HttpContext context)
        {
            // Set the status code to 422 Unprocessable Entity for validation errors
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

            // Prepare detailed validation errors response
            var validationErrors = validationException.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );

            // Write the validation errors response
            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "Validation failed.",
                errors = validationErrors
            };

            // Write the response asynchronously
            context.Response.WriteAsync(JsonSerializer.Serialize(response));
            return context.Response.StatusCode; // Return the status code
        }
    }
}
