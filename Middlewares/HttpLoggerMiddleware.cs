using System.Diagnostics;

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
        var stopwatch = new Stopwatch();
        stopwatch.Start();
    
        _logger.LogInformation("Request received. {RequestPath}", context.Request.Path);
    
        await next(context);
    
        stopwatch.Stop();
        _logger.LogInformation("Request processed in {ElapsedMilliseconds}ms. {StatusCode}", stopwatch.ElapsedMilliseconds, context.Response.StatusCode);
    }
}
