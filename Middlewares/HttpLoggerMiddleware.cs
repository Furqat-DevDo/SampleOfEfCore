namespace EfCore.Middlewares;

public class HttpLoggerMiddleware : IMiddleware
{
    private readonly ILogger<HttpLoggerMiddleware> _logger;
    public HttpLoggerMiddleware(ILogger<HttpLoggerMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation($"{context.Request.Path} dan request ketti");

        await next(context);

        _logger.LogInformation($" Va unga {context.Response.StatusCode} degan status code qaytdi.");
    }
}
