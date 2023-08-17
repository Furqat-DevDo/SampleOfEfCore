namespace EfCore.Middlewares;

public class HttpLogger : IMiddleware
{
    private readonly ILogger<HttpLogger> _logger;
    public HttpLogger(ILogger<HttpLogger> logger)
    {
        _logger = logger;
    }
    public async  Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogCritical($"{context.Request.Path} dan request ketti");
        
        await next (context);

        _logger.LogCritical($" Va unga {context.Response.StatusCode} degan status code qaytdi.");
    }
}
