using System.Net;

namespace NZWalks.API.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            var errorId = Guid.NewGuid();

            _logger.LogError(ex, "{ErrorId} : Server Error", errorId);

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var errorResult = new
            {
                Id = errorId,
                ErrorMessage = "Something went wrong! we are looking into resolving this"
            };

            await httpContext.Response.WriteAsJsonAsync(errorResult);
            
        }
    }
}
