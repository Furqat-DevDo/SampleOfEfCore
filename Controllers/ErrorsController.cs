using EfCore.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {       
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        switch(exception)
        {
            case BaseNotFoundException:
                return Problem(title: exception?.Message, statusCode: 404);
            case ValidationException:
                return Problem(title: exception?.Message, statusCode: 400);
            default:
                return Problem(title: "Internal Server Error", statusCode: 500);
        }
        
    }
}
