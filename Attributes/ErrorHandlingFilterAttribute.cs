using EfCore.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace EfCore.Attributes;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{

    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = exception.Message,
            Detail = exception.ToString(),
            Status = (int)HttpStatusCode.InternalServerError,
        };

        var exceptionHandlers = new Dictionary<Type, Action<ProblemDetails>>
        {
            { typeof(BaseNotFoundException), (problemDetails) =>
                {
                    problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Title = exception.Message;
                    problemDetails.Detail = exception.ToString();
                }
            },
            // add additional exception types and handlers as needed
        };
        
        if (exceptionHandlers.TryGetValue(exception.GetType(), out var handler))
        {
            handler(problemDetails);
        }
        
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
