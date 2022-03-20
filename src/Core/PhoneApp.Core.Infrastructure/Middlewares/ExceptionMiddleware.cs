using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneApp.Core.Domain.Exceptions;
using PhoneApp.Core.Domain.Logging;
using PhoneApp.Core.Domain.Responses;

namespace PhoneApp.Core.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogPort _logPort;
        public ExceptionMiddleware(RequestDelegate next, ILogPort logPort)
        {
            _logPort = logPort;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                var statusCode = StatusCodes.Status500InternalServerError;
                var appResponse = default(ResponseWrapper<object>);
                var exceptionId = "SYS-101";
                var errors = default(IEnumerable<string>);

                if (exception is BusinessValidationException businessValidationException)
                {
                    _logPort.LogError($"Business Exception > {businessValidationException.Message}", businessValidationException);

                    appResponse = new ResponseWrapper<object>(businessValidationException.Status, businessValidationException.ExceptionId, businessValidationException.DisplayMessage);
                }
                else if (exception is FluentValidation.ValidationException validationException)
                {
                    statusCode = StatusCodes.Status400BadRequest;
                    exceptionId = "VAL-101";
                    errors = validationException.Errors.Select(x => x.ErrorMessage).ToList();

                    _logPort.LogError($"Validation Exception > {validationException.Message}", validationException);

                    appResponse = new ResponseWrapper<object>(statusCode, exceptionId, errors);
                }
                else if (exception is DomainException domainException)
                {
                    _logPort.LogError($"Domain Exception > {domainException.Message}", domainException);

                    appResponse = new ResponseWrapper<object>(domainException.Status, domainException.ExceptionId, domainException.DisplayMessage);
                }
                else
                {
                    _logPort.LogError($"Exception > {exception.Message}", exception);

                    appResponse = new ResponseWrapper<object>(500, exceptionId, exception.Message);
                }

                response.StatusCode = appResponse.StatusCode;
                var json = JsonConvert.SerializeObject(appResponse);
                await response.WriteAsync(json);
            }
        }
    }
}
